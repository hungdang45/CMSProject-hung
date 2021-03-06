﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSProject.Models;
using PagedList;

namespace CMSProject.Client.Controllers
{
    public class ClientsController : Controller
    {
        List<Carts> lstCarts = new List<Carts>();
        private CMSEntities db = new CMSEntities();
        List<OrderClients> lstOrderClients = new List<OrderClients>();
        // GET: ListProducts

        public PartialViewResult GetPaging(int? page)
        {
            List<Product> lstproduct = new List<Product>();
            lstproduct = db.Products.ToList();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewProduct", lstproduct.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ProductPagedIndex()
        {
            return View();
        }

        public ActionResult ProductIndex()
        {
            if (Session["CustomerID"] != null)
            {
                ViewBag.IdOrd = Int32.Parse(Session["CustomerID"].ToString());
            }
            ViewBag.lstCategories = db.Categories.ToList();
            var lstPro = db.Products.Where(n => n.Status == 1).ToList();
            return View(lstPro);
        }

        //Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public ActionResult AddToCartClient(int id, int? IdOrderClient)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login", "Customers");
            }
            else
            {
                bool flag = false;
                int idOrder = IdOrderClient.Value;
                if (Session["Cart"] == null)
                {
                    lstCarts = new List<Carts>();
                }
                else
                {
                    lstCarts = Session["Cart"] as List<Carts>;
                    var listCart = lstCarts.Where(n => n.OrderID == idOrder).ToList();
                    foreach (var carts in listCart)
                    {
                        if (carts.ProductID == id)
                        {
                            flag = true;
                            carts.Quantity += 1;
                            carts.Total = carts.UnitPrice * carts.Quantity;
                            break;
                        }
                    }
                }
                Product product = db.Products.Where(n => n.ProductID == id).FirstOrDefault();
                if (flag == false)
                {
                    Carts c = new Carts();
                    c.ProductID = id;
                    c.OrderID = idOrder;
                    c.ProductName = product.ProductName;
                    c.Quantity = 1;
                    c.UnitPrice = Convert.ToDecimal(product.Price);
                    c.Total = c.UnitPrice * c.Quantity;
                    lstCarts.Add(c);
                }
                Session["Cart"] = lstCarts;
                return RedirectToAction("ProductIndex");
            }
        }

        //Hiển thị danh sachsanr phẩm trong giỏ hàng
        public ActionResult ClientCartIndex(int? id)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login", "Customers");
            }
            else
            {
                if (Session["Order"] == null)
                {
                    lstOrderClients = new List<OrderClients>();
                }
                else
                {
                    lstOrderClients = Session["Order"] as List<OrderClients>;
                }
                if (Session["Cart"] == null)
                {
                    lstCarts = new List<Carts>();
                }
                else
                {
                    lstCarts = Session["Cart"] as List<Carts>;
                }
                var dataCarts = lstCarts.Where(n => n.OrderID == id).ToList();
                if (dataCarts.Count > 0)
                {
                    TempData["TotalCart"] = dataCarts.Sum(n => n.Total);
                }
                else
                {
                    TempData["TotalCart"] = 0;
                }
                ViewBag.totalCart = TempData["TotalCart"];
                ViewBag.Error = TempData["ErrorQuantity"];
                ViewBag.messageSuccess = TempData["MessageSuccess"];
                OrderClients order = lstOrderClients.Find(n => n.OrderID == id);
                return View(order);
            }
        }

        // Danh sách sản phẩm đã được thêm vào giỏ hàng
        public ActionResult _ListCartClient()
        {
            if (Session["Cart"] == null)
            {
                lstCarts = new List<Carts>();
            }
            else
            {
                lstCarts = Session["Cart"] as List<Carts>;
            }
            int IdOrd = Int32.Parse(Session["CustomerID"].ToString());
            var dataCarts = lstCarts.Where(n => n.OrderID == IdOrd).ToList();
            return View(dataCarts);
        }

        public ActionResult BlogIndex()
        {
            var lstBlog = db.Blogs.ToList();
            return View(lstBlog);
        }

        public ActionResult BlogDetail(int? id)
        {

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var blog = db.Blogs.Where(x => x.BlogID == id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        public ActionResult CustomerDetail(int? id)
        {

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var customer = db.Customers.Where(x => x.CustomerID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult ProductDetail(int? id)
        {
            var product = db.Products.Where(n => n.ProductID == id).FirstOrDefault();
            if (product == null)
            {
                return RedirectToAction("ProductIndex");
            }
            return View(product);
        }

        //Xóa sản phẩm trong giỏ hàng
        [HttpPost]
        public ActionResult RemoveProductInCart(int id, int? idOrd)
        {
            if (Session["Cart"] != null)
            {
                lstCarts = Session["Cart"] as List<Carts>;
            }
            if (lstCarts != null)
            {
                Carts c = lstCarts.Where(n => n.ProductID == id).FirstOrDefault();
                lstCarts.Remove(c);
            }
            int idOrder = idOrd.Value;
            return RedirectToAction("ClientCartIndex/" + idOrder);
        }

        //Cập nhật số lượng trong giỏ hàng
        [HttpPost]
        public ActionResult UpdateQuantity(int id, int quantitied, int? idOrd)
        {
            if (Session["Cart"] != null)
            {
                lstCarts = Session["Cart"] as List<Carts>;
            }
            var listCart = lstCarts.Where(n => n.OrderID == idOrd).ToList();
            if (listCart != null)
            {
                var product = db.Products.Where(n => n.ProductID == id).ToList();
                foreach (var pro in product)
                {
                    if (quantitied <= pro.Quantity)
                    {
                        listCart.Where(n => n.ProductID == id).FirstOrDefault().Quantity = quantitied;
                        listCart.Where(n => n.ProductID == id).FirstOrDefault().Total = lstCarts.Where(n => n.ProductID == id).FirstOrDefault().UnitPrice * quantitied;
                    }
                    else
                    {
                        TempData["ErrorQuantity"] = "Rất tiếc, số lượng của một sản phẩm mà bạn cần không đủ so với trong kho của chúng tôi! Vui lòng nhập lại.";
                    }
                }
            }
            int idOrder = idOrd.Value;
            Session["Cart"] = lstCarts;
            return RedirectToAction("ClientCartIndex/" + idOrder);
        }


        //public ActionResult SaveToOrder()
        //{
        //    ViewBag.messageSuccess = TempData["ViewBag.messageSuccess"];
        //    return View("ProductIndex");
        //}
        //Lưu lại Order và OrderDetail
        //Them viewbag message success  
        public ActionResult SaveToOrder(int? id)
        {
            if (Session["Cart"] == null)
            {
                lstCarts = new List<Carts>();
            }
            else
            {
                lstCarts = Session["Cart"] as List<Carts>;
            }
            if (Session["Order"] == null)
            {
                lstOrderClients = new List<OrderClients>();
            }
            else
            {
                lstOrderClients = Session["Order"] as List<OrderClients>;
            }
            //int idClient = Convert.ToInt32(Session["UserId"]);
            var listOrderClient = lstOrderClients.Where(n => n.CustomerID == id).FirstOrDefault();
            Order order = new Order();
            order.CustomerID = id;
            order.OrderName = 2;
            order.CustomerName = listOrderClient.CustomerName;
            order.CustomerEmail = listOrderClient.CustomerEmail;
            order.Phone = listOrderClient.Phone;
            order.CreateDate = DateTime.Now;
            order.OrderCreate = listOrderClient.CustomerName;
            order.Status = 1;
            db.Orders.Add(order);
            db.SaveChanges();
            //Lấy ra idOrder cuối cùng
            var listOrders = db.Orders.Where(n => n.CustomerID == id).ToList();
            int idOrderMax = listOrders.Max(n => n.OrderID);
            //Tiến hành lưu từ Cart vào OrderDetail
            var listCart = lstCarts.Where(n => n.OrderID == id).ToList();
            foreach (var c in listCart)
            {
                var product = db.Products.Where(n => n.ProductID == c.ProductID).ToList();
                OrderDetail orderDetail = new OrderDetail();
                foreach (var pro in product)
                {
                    if (c.Quantity <= pro.Quantity)
                    {
                        orderDetail.ProductID = c.ProductID;
                        orderDetail.OrderID = idOrderMax;
                        orderDetail.Quantity = c.Quantity;
                        orderDetail.UnitPrice = c.UnitPrice;
                        orderDetail.Total = c.Total;
                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();
                        //Tiến hành cập nhật lại số lượng của product
                        //var pro = db.Products.Where(n => n.ProductID == c.ProductID).FirstOrDefault();
                        pro.UpdateBy = listOrderClient.CustomerName;
                        pro.Quantity -= c.Quantity;
                        db.Entry(pro).State = EntityState.Modified;
                        db.SaveChanges();
                        //Tiến hành xóa sản phẩm đã đặt rồi ở trong giỏ hàng
                        Carts removeCart = listCart.Where(n => n.ProductID == c.ProductID).FirstOrDefault();
                        lstCarts.Remove(removeCart);
                        TempData["MessageSuccess"] = "Ban da dat hang thanh cong";
                    }
                    else
                    {
                        TempData["ErrorQuantity"] = "Rất tiếc, số lượng của một sản phẩm mà bạn cần không đủ so với trong kho của chúng tôi! Vui lòng nhập lại.";
                    }
                }
            }
            //Tiến hành tính tổng tiền đơn hàng đó và cập nhật tổng tiền vào Order
            if (listCart.Count > 0)
            {
                TempData["TotalOrder"] = listCart.Sum(n => n.Total);
            }
            else
            {
                TempData["TotalOrder"] = 0;
            }
            Order ord = db.Orders.Where(n => n.OrderID == idOrderMax).FirstOrDefault();
            ord.Total = Convert.ToDecimal(TempData["TotalOrder"]);
            db.Entry(ord).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.messageSuccess = TempData["ViewBag.messageSuccess"];
            //return RedirectToAction("ProductIndex");
            return RedirectToAction("ClientCartIndex/"+id);
        }

        //Feedback từ khách hàng
        public ActionResult ClientFeedback()
        {
            ViewBag.messageSuccess = TempData["ViewBag.messageSuccess"];
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientFeedback(Feedback feedback)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login", "Customers");
            }
            else
            {
                feedback.CustomerID = Convert.ToInt32(Session["CustomerID"]);
                feedback.DateCreated = DateTime.Now;
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                TempData["ViewBag.messageSuccess"] = "Gửi đi thành công!";
                return RedirectToAction("ClientFeedback");
            }
        }

        //Xem trang cá nhân
        public ActionResult ClientDetail(int? id)
        {
            var client = db.Customers.Find(id);
            return View(client);
        }

        //Chỉnh sửa tài khoản
        public ActionResult ClientEdit(int id)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login", "Customers");
            }
            else
            {
                var dataClient = db.Customers.Find(id);
                return View(dataClient);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientEdit(Customer customer)
        {
            if (Session["CustomerID"] == null)
            {
                return RedirectToAction("Login", "Customers");
            }
            else
            {
                customer.Password = Crypto.Hash(customer.Password);
                int idClient = Int32.Parse(Session["CustomerID"].ToString());
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClientDetail/" + idClient);
            }
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}