using System;
using System.ComponentModel.DataAnnotations;

namespace uBlog.DAL.Entities
{
    public class Article
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
