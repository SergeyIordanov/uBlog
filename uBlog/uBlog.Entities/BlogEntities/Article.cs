using System;
using System.Collections.Generic;

namespace uBlog.Entities.BlogEntities
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}
