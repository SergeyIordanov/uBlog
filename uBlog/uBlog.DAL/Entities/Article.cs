using System;
using System.Collections.Generic;

namespace uBlog.DAL.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
