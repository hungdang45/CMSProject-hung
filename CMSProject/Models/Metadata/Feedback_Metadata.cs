using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSProject.Models
{
    [MetadataType(typeof(Feedback.Metadata))]
    public partial class Feedback
    {
        sealed class Metadata
        {
            public int FeedbackID { get; set; }
            [Display(Name ="Khách hàng")]
            public Nullable<int> CustomerID { get; set; }
            [Display(Name = "Nội dung")]
            [Required(ErrorMessage ="Nội dung không được để trống")]
            public string FeedbackContent { get; set; }
            [Display(Name = "Ngày gửi")]
            public Nullable<System.DateTime> DateCreated { get; set; }
        }
    }
}