using System;
using System.ComponentModel.DataAnnotations;

namespace uBlog.DAL.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string AuthorName { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
