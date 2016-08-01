using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uBlog.WEB.Models
{
    public class TagViewModel
    {
        [Required]
        public int TagId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ICollection<ArticleViewModel> Articles { get; set; }
    }
}