using System.Collections.Generic;
using uBlog.BLL.DataTransferObjects;

namespace uBlog.BLL.Interfaces
{
    public interface IBlogService
    {
        void CreateArticle(ArticleDTO articleDTO);
        void CreateReview(ReviewDTO reviewDTO);
        void CreateUserInfo(UserInfoDTO userInfoDTO);
        UserInfoDTO GetUserInfo(int? id);
        IEnumerable<ArticleDTO> GetArticles();
        IEnumerable<ReviewDTO> GetReviewes();
        void Dispose();
    }
}
