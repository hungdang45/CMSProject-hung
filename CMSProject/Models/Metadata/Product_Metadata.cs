using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(Product.Metadata))]
    public partial class Product
    {
        sealed class Metadata
        {
            public int ProductID { get; set; }
            [Display(Name ="Sản phẩm")]
            [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
            public string ProductName { get; set; }
            [Display(Name = "Thương hiệu")]
            [Required(ErrorMessage = "Thương hiệu không được để trống")]
            public string Brand { get; set; }
            [Display(Name = "Kích cỡ")]
            public string Size { get; set; }
            [Display(Name = "Mô tả")]
            public string Description { get; set; }
            [Display(Name = "Giá bán")]
            public Nullable<decimal> Price { get; set; }
            [Display(Name = "Mã sản phẩm")]
            [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
            public string ProductCode { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Status { get; set; }
            [Display(Name = "Hình ảnh")]
            [Required(ErrorMessage ="Hình ảnh không được để trống")]
            public byte[] ImageUpload { get; set; }
            public Nullable<int> CategoryID { get; set; }
            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> DateCreated { get; set; }
            [Display(Name = "Ngày cập nhật")]
            public Nullable<System.DateTime> DateUpdated { get; set; }
            [Display(Name = "Người tạo")]
            public string CreatedBy { get; set; }
            [Display(Name = "Người cập nhật")]
            public string UpdateBy { get; set; }
            [Display(Name = "Đơn vị tính")]
            [Required(ErrorMessage = "Đơn vị tính không được để trống")]
            public string Unit { get; set; }
            [Display(Name = "Số lượng")]
            public Nullable<int> Quantity { get; set; }
        }
    }
}