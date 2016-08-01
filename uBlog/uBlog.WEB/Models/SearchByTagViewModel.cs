using System.Collections.Generic;

namespace uBlog.WEB.Models
{
    public class SearchByTagViewModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        public string TagText { get; set; }
    }
}