using System.Collections.Generic;

namespace uBlog.WEB.ViewModels
{
    public class SearchByTagViewModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        public string TagText { get; set; }
    }
}