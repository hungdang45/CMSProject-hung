using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSProject.Models;

namespace CMSProject.Controllers
{
    public class WareHouseController : Controller
    {
        private CMSEntities db = new CMSEntities();
        // GET: WareHouse
        public ActionResult Index()
        {
            var dataWareHouse = db.Products.ToList();
            return View(dataWareHouse);
        }
    }
}