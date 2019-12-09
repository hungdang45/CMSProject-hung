using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(Account.Metadata))]
    public partial class Account
    {
        sealed class Metadata
        {
            public int AccountID { get; set; }
            [Display(Name = "Tên đăng nhập")]
            [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
            public string UserName { get; set; }
            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "Mật khẩu không được để trống")]
            public string Password { get; set; }
            [Display(Name = "Quyền hạn")]
            public Nullable<byte> Roles { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Status { get; set; }
        }
    }
}