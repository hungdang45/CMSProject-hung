using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMSProject.Models
{
    [MetadataType(typeof(Blog.Metadata))]
    public partial class Blog
    {
        sealed class Metadata
        {
            public int BlogID { get; set; }
            [Display(Name = "Tên bài viết")]
            [Required(ErrorMessage = "Tên bài viết không được để trống")]
            public string BlogTitle { get; set; }
            [Display(Name = "Nội dung bài viết")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            [Required(ErrorMessage = "Nội dung bài viết không được để trống")]
            public string BlogContent { get; set; }
            [Display(Name = "Tác giả")]
            public string Author { get; set; }
            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> DateCreated { get; set; }
        }
    }
}