using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSProject.Models
{
    public class Carts
    {
        public int OrderDetail_ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        [Display(Name ="Sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Giá bán")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Thành tiền")]
        public decimal Total { get; set; }
    }
}