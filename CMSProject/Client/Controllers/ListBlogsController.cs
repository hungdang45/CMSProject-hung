using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSProject.Client.Controllers
{
    public class ListBlogsController : Controller
    {
        // GET: ListBlogs
        public ActionResult Index()
        {
            return View();
        }
    }
}