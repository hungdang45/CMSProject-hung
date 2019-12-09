using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(Order.Metadata))]
    public partial class Order
    {
        sealed class Metadata
        {
            public int OrderID { get; set; }
            [Display(Name ="Đơn hàng")]
            public Nullable<byte> OrderName { get; set; }
            public Nullable<int> CustomerID { get; set; }
            [Display(Name = "Khách hàng")]
            [Required(ErrorMessage = "Tên khách hàng không được để trống")]
            public string CustomerName { get; set; }
            [Display(Name = "Email")]
            [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Định dạng Email không hợp lệ")]
            [Required(ErrorMessage = "Email không được để trống")]
            public string CustomerEmail { get; set; }
            [Display(Name = "Giới tính")]
            public Nullable<byte> Gender { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Điện thoại không được để trống")]
            public string Phone { get; set; }
            [Display(Name = "Giao đến")]
            [Required(ErrorMessage = "Địa chỉ giao không được để trống")]
            public string ShipAddress { get; set; }
            [Display(Name = "Người tạo")]
            public string OrderCreate { get; set; }
            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> CreateDate { get; set; }
            [Display(Name = "Người giao")]
            public string Shipper { get; set; }
            [Display(Name = "Ngày giao")]
            public Nullable<System.DateTime> ShipDate { get; set; }
            [Display(Name = "Nhận tiền")]
            public string Receiver { get; set; }
            [Display(Name = "Ngày nhận")]
            public Nullable<System.DateTime> PayDate { get; set; }
            [Display(Name = "Tổng tiền")]
            public Nullable<decimal> Total { get; set; }
            [Display(Name = "Chú thích")]
            public string Note { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Status { get; set; }
        }
    }
}