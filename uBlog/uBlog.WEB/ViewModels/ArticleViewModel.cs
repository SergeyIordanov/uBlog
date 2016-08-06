using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace uBlog.WEB.ViewModels
{
    public class ArticleViewModel
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [DisplayName("Date of publishing")]
        [Required]
        public DateTime PublishDate { get; set; }

        public List<string> Tags { get; set; }

        public ArticleViewModel()
        {
            Tags = new List<string>();
        }
    }
}