using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(Supplier.Metadata))]
    public partial class Supplier
    {
        sealed class Metadata
        {
            public int SupplierID { get; set; }
            [Display(Name ="Nhà phân phối")]
            [Required(ErrorMessage ="Nhà phân phối không được để trống")]
            public string SupplierName { get; set; }
            [Display(Name = "Chi tiết khác")]
            public string OtherDetails { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Địa chỉ không được để trống")]
            public string ContactAddress { get; set; }
            [Display(Name = "Email")]
            [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Định dạng Email không hợp lệ")]
            [Required(ErrorMessage = "Email không được để trống")]
            public string ContactEmail { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Điện thoại không được để trống")]
            public string ContactPhone { get; set; }
            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> AddedDate { get; set; }
            [Display(Name = "Ngày cập nhật")]
            public Nullable<System.DateTime> UpdateDate { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Status { get; set; }
        }
    }
}