using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM_MVC_2.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
    }
}