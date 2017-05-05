using ButterCMS;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System.Net;

namespace ButterCmsExample.Controllers
{
    public class BlogController : Controller
    {
        private ButterCMSClient Client;

        private static string _apiToken = "de55d3f93789d4c5c26fb07445b680e8bca843bd";

        public BlogController()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Client = new ButterCMSClient(_apiToken);
        }

        [Route("")]
        [Route("blog")]
        [Route("blog/p/{page}")]
        public async Task<ActionResult> ListAllPosts(int page = 1)
        {
            var response = await Client.ListPostsAsync(page, 10);
            ViewBag.Posts = response.Data;
            ViewBag.NextPage = response.Meta.NextPage;
            ViewBag.PreviousPage = response.Meta.PreviousPage;
            return View("Posts");
        }

        [Route("blog/{slug}")]
        public async Task<ActionResult> ShowPost(string slug)
        {
            var response = await Client.RetrievePostAsync(slug);
            ViewBag.Post = response.Data;
            return View("Post");
        }

        [Route("authors")]
        public async Task<ActionResult> ListAllAuthors()
        {
            var response = await Client.ListAuthorsAsync(false);
            ViewBag.Authors = response;
            return View("Authors");
        }

        [Route("author/{slug}")]
        [Route("author/{slug}/p/{page}")]
        public async Task<ActionResult> ShowAuthor(string slug, int page = 1)
        {
            var authorResponse = await Client.RetrieveAuthorAsync(slug, false);
            var postsResponse = await Client.ListPostsAsync(page, 10, true, slug);
            ViewBag.Posts = postsResponse.Data;
            ViewBag.Author = authorResponse;
            ViewBag.NextPage = postsResponse.Meta.NextPage;
            ViewBag.PreviousPage = postsResponse.Meta.PreviousPage;
            return View("Author");
        }

        [Route("categories")]
        public async Task<ActionResult> ListAllCategories()
        {
            var response = await Client.ListCategoriesAsync(false);
            ViewBag.Categories = response;
            return View("Categories");
        }

        [Route("category/{slug}")]
        [Route("category/{slug}/p/{page}")]
        public async Task<ActionResult> ShowCategory(string slug, int page = 1)
        {
            var categoryResponse = await Client.RetrieveCategoryAsync(slug, false);
            var postsResponse = await Client.ListPostsAsync(page, 10, true, null, slug);
            ViewBag.Posts = postsResponse.Data;
            ViewBag.Category = categoryResponse;
            ViewBag.NextPage = postsResponse.Meta.NextPage;
            ViewBag.PreviousPage = postsResponse.Meta.PreviousPage;
            return View("Category");
        }

        [Route("tags")]
        public async Task<ActionResult> ListAllTags()
        {
            var response = await Client.ListTagsAsync(false);
            ViewBag.Tags = response;
            return View("Tags");
        }

        [Route("tag/{slug}")]
        [Route("tag/{slug}/p/{page}")]
        public async Task<ActionResult> ShowTag(string slug, int page = 1)
        {
            var tagResponse = await Client.RetrieveTagAsync(slug, false);
            var postsResponse = await Client.ListPostsAsync(page, 10, true, null, null, slug);
            ViewBag.Posts = postsResponse.Data;
            ViewBag.Tag = tagResponse;
            ViewBag.NextPage = postsResponse.Meta.NextPage;
            ViewBag.PreviousPage = postsResponse.Meta.PreviousPage;
            return View("Tag");
        }

        [Route("faq")]
        public async Task<ActionResult> ShowFaq()
        {
            var json = await Client.RetrieveContentFieldsJSONAsync(new[] {
                "faq_headline",
                "faq_items"
            });
            dynamic faq = JsonConvert.DeserializeObject(json);
            ViewBag.FaqHeadline = faq.data.faq_headline;
            ViewBag.FaqItems = faq.data.faq_items;
            return View("Faq");
        }

        [Route("locations")]
        public ActionResult ListAllLocations()
        {
            return View("Locations");
        }

        [Route("location/{slug}")]
        public async Task<ActionResult> ShowLocation(string slug)
        {
            var json = await Client.RetrieveContentFieldsJSONAsync(new[]
            {
                $"location_pages[slug={slug}]"
            });
            dynamic page = ((dynamic)JsonConvert.DeserializeObject(json)).data.location_pages[0];
            ViewBag.FeatureImage = page.feature_image; 
            ViewBag.Name = page.name; 
            ViewBag.Description = page.description; 
            return View("Location");
        }

        [Route("feeds/rss")]
        public async Task<ActionResult> ShowRss()
        {
            var xmlDoc = await Client.GetRSSFeedAsync();
            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw))
                {
                    xmlDoc.WriteTo(xw);
                    xw.Flush();
                    return Content(sw.GetStringBuilder().ToString(), "text/xml");
                }
            }
        }

        [Route("feeds/atom")]
        public async Task<ActionResult> ShowAtom()
        {
            var xmlDoc = await Client.GetAtomFeedAsync();
            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw))
                {
                    xmlDoc.WriteTo(xw);
                    xw.Flush();
                    return Content(sw.GetStringBuilder().ToString(), "text/xml");
                }
            }
        }

        [Route("sitemap")]
        public async Task<ActionResult> ShowSitemap()
        {
            var xmlDoc = await Client.GetSitemapAsync();
            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw))
                {
                    xmlDoc.WriteTo(xw);
                    xw.Flush();
                    return Content(sw.GetStringBuilder().ToString(), "text/xml");
                }
            }
        }

    }
}