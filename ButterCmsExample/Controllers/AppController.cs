using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ButterCMS;

namespace ButterCmsExample.Controllers
{
    public abstract class AppController : Controller
    {
        private string _authToken = "b60a008584313ed21803780bc9208557b3b49fbb";

        protected ButterCMSClient Client => new ButterCMSClient(_authToken);

    }
}