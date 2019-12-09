using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(OrderDetail.Metadata))]
    public partial class OrderDetail
    {
        sealed class Metadata
        {
            public int OrderDetail_ID { get; set; }
            public Nullable<int> OrderID { get; set; }
            public Nullable<int> ProductID { get; set; }
            [Display(Name ="Sản phẩm")]
            public string ProductName { get; set; }
            [Display(Name = "Số lượng")]
            public Nullable<int> Quantity { get; set; }
            [Display(Name = "Giá bán")]
            public Nullable<decimal> UnitPrice { get; set; }
            [Display(Name = "Thành tiền")]
            public Nullable<decimal> Total { get; set; }
        }
    }
}