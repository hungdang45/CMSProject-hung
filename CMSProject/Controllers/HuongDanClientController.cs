using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSProject.Controllers
{
    public class HuongDanClientController : Controller
    {
        // GET: HuongDanClient
        public ActionResult HuongDanMuaHang()
        {
            return View();
        }
        public ActionResult HuongDanThanhToan()
        {
            return View();
        }
    }
}