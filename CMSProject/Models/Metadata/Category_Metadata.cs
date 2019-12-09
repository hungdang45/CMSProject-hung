using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(Category.Metadata))]
    public partial class Category
    {
        sealed class Metadata
        {
            public int CategoryID { get; set; }
            [Display(Name = "Tên loại sản phẩm")]
            [Required(ErrorMessage = "Tên loại sản phẩm không được bỏ trống")]
            public string CategoryName { get; set; }
        }
    }
}