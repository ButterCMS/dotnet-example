using ButterCMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ButterCmsExample.Controllers
{
    public class HomeController : Controller
    {
        private ButterCMSClient Client;

        public HomeController()
        {
            Client = new ButterCMSClient("b60a008584313ed21803780bc9208557b3b49fbb");
        }

        [Route("")]
        [Route("page/{page}")]
        public async Task<ActionResult> Index(int page = 1)
        {
            var response = await Client.ListPostsAsync(page);

            ViewBag.Posts = response.Data;

            if (response.Meta.NextPage.HasValue)
            {
                ViewBag.HasNext = true;
                ViewBag.NextPage = response.Meta.NextPage;
            }
            else
            {
                ViewBag.HasNext = false;
            }

            if (response.Meta.PreviousPage.HasValue)
            {
                ViewBag.HasPrevious = true;
                ViewBag.PreviousPage = response.Meta.PreviousPage;
            }
            else
            {
                ViewBag.HasPrevious = false;
            }

            return View("~/Views/Index.cshtml");
        }

        [Route("post/{slug}")]
        public async Task<ActionResult> Post(string slug)
        {
            var response = await Client.RetrievePostAsync(slug);
            ViewBag.Post = response.Data;
            return View("~/Views/Post.cshtml");
        }

    }
}