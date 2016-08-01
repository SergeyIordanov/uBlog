using System.Collections.Generic;

namespace uBlog.DAL.Entities
{
    public class Tag
    {
        public int TagId { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Article> Articles { get; set; }  
    }
}
