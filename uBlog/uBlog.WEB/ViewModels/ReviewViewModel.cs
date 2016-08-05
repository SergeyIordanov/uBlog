using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace uBlog.WEB.ViewModels
{
    public class ReviewViewModel
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        [DisplayName("Author")]
        public string AuthorName { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [DisplayName("Date of publishing")]
        public DateTime PublishDate { get; set; }
    }
}