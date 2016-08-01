using System.Collections.Generic;

namespace uBlog.BLL.DataTransferObjects
{
    public class TagDto
    {
        public int TagId { get; set; }

        public string Text { get; set; }

        public virtual ICollection<ArticleDto> Articles { get; set; }
    }
}
