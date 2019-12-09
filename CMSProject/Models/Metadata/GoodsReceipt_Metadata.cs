using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(GoodsReceipt.Metadata))]
    public partial class GoodsReceipt
    {
        sealed class Metadata
        {
            public int GoodsReceiptID { get; set; }
            public Nullable<int> SupplierID { get; set; }
            [Display(Name ="Tên phiếu nhập")]
            [Required(ErrorMessage ="Tên phiếu nhập không được để trống")]
            public string GoodsReceiptName { get; set; }
            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> AddedDate { get; set; }
            [Display(Name = "Người tạo")]
            public string Creator { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Status { get; set; }
            [Display(Name = "Tổng tiền")]
            public Nullable<decimal> Total { get; set; }
        }
    }
}