using System;
using System.ComponentModel;

namespace uBlog.WEB.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        [DisplayName("Author")]
        public string AuthorName { get; set; }

        public string Text { get; set; }

        [DisplayName("Date of publishing")]
        public DateTime PublishDate { get; set; }
    }
}