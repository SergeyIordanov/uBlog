using System;
using System.ComponentModel;

namespace uBlog.WEB.Models
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [DisplayName("Date of publishing")]
        public DateTime PublishDate { get; set; }
    }
}