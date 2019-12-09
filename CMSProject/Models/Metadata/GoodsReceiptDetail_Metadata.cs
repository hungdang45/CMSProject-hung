using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(GoodsReceiptDetail.Metadata))]
    public partial class GoodsReceiptDetail
    {
        sealed class Metadata
        {
            public int GoodsReceiptDetailID { get; set; }
            public Nullable<int> GoodsReceiptID { get; set; }
            [Display(Name ="Số lượng")]
            public Nullable<int> Quantity { get; set; }
            [Display(Name = "Giá nhập")]
            public Nullable<decimal> UnitPrice { get; set; }
            [Display(Name = "Tổng nhập")]
            public Nullable<decimal> Total { get; set; }
            public Nullable<int> ProductID { get; set; }
        }
    }
}