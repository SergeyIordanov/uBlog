using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM_MVC_2.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
    }
}