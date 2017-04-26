using ButterCMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ButterCmsExample.Controllers
{
    public class BlogController : Controller
    {
        private ButterCMSClient Client;

        private static string _apiToken = "b60a008584313ed21803780bc9208557b3b49fbb";

        public BlogController()
        {
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




    }
}