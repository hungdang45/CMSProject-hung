using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(Customer.Metadata))]
    public partial class Customer
    {
        sealed class Metadata
        {
            public int CustomerID { get; set; }
            [Display(Name ="Họ và tên")]
            [Required(ErrorMessage ="Họ tên không được để trống")]
            public string CustomerName { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage ="Địa chỉ không được để trống")]
            public string Address { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage ="Điện thoại không được để trống")]
            public string Phone { get; set; }
            [Display(Name = "Email")]
            [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Định dạng Email không hợp lệ")]
            [Required(ErrorMessage ="Email không được để trống")]
            public string Email { get; set; }
            [Display(Name = "Mật khẩu")]
            [MinLength(6,ErrorMessage ="Mật khẩu ít nhất 6 ký tự")]
            [Required(ErrorMessage ="Mật khẩu không được để trống")]
            public string Password { get; set; }
            [Display(Name = "Tỉnh/thành")]
            [Required(ErrorMessage ="Tỉnh thành không được để trống")]
            public string City { get; set; }
            [Display(Name = "Đất nước")]
            public string Country { get; set; }
            public Nullable<bool> IsEmailVerified { get; set; }
            public Nullable<System.Guid> ActivationCode { get; set; }
        }
    }
}