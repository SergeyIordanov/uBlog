using System;

namespace uBlog.BLL.DataTransferObjects
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
