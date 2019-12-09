using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(spud_DoanhThuSPTheoThang_Result.Metadata))]
    public partial class spud_DoanhThuSPTheoThang_Result
    {
        sealed class Metadata
        {
            [Display(Name ="Năm tháng")]
            public string NamThang { get; set; }
            [Display(Name = "Sản phẩm")]
            public string productName { get; set; }
            public int productID { get; set; }
            [Display(Name = "Tổng nhập")]
            public Nullable<int> TongSLN { get; set; }
            [Display(Name = "Tổng xuất")]
            public Nullable<int> TongSlX { get; set; }
            [Display(Name = "Tổng trị giá nhập")]
            public Nullable<decimal> TongTriGiaNhap { get; set; }
            [Display(Name = "Tổng trị giá xuất")]
            public Nullable<decimal> TongTriGiaXuat { get; set; }
        }
    }
}