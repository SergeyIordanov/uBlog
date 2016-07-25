using System;
using System.ComponentModel.DataAnnotations;

namespace uBlog.DAL.Entities
{
    public class Review
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
