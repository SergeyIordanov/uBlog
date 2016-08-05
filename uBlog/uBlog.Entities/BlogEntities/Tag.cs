using System.Collections.Generic;

namespace uBlog.Entities.BlogEntities
{
    public class Tag
    {
        public int TagId { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}
