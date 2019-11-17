using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSProject.Models;

namespace CMSProject.Client.Controllers
{
    public class ClientsController : Controller
    {
        List<Carts> lstCarts = new List<Carts>();
        private CMSEntities db = new CMSEntities();
        // GET: ListProducts
        public ActionResult Index()
        {
            ViewBag.lstCategories = db.Categories.ToList();
            var lstPro = db.Products.ToList();
            return View(lstPro);
        }
        

        //public ActionResult CreateProduct(int? id, int? ordId)
        //{
        //    if (Session["Carts"] == null)
        //    {
        //        lstCarts = new List<Carts>();
        //    }
        //    else
        //    {
        //        lstCarts = Session["Carts"] as List<Carts>;
        //    }
        //    Product pro = db.Products.Where(n => n.ProductID == id).FirstOrDefault();
        //    Carts c = new Carts();
        //    int IdOrd = ordId.Value;
        //    c.OrderID = IdOrd;
        //    c.ProductID = id.Value;
        //    c.ProductName = pro.ProductName;
        //    c.Quantity = 1;
        //    c.UnitPrice = Convert.ToDecimal(pro.Price);
        //    c.Total = c.Quantity * c.UnitPrice;
        //    lstCarts.Add(c);
        //    Session["Carts"] = lstCarts;
        //    return RedirectToAction("/CreateProduct/" + IdOrd);
        //}
        
        public ActionResult BlogIndex()
        {
            var lstBlog = db.Blogs.ToList();
            return View(lstBlog);
        }
    }
}