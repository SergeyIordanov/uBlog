using System.Collections.Generic;
using uBlog.BLL.DataTransferObjects;

namespace uBlog.BLL.Interfaces
{
    public interface IBlogService
    {
        void CreateArticle(ArticleDto articleDto);
        void CreateReview(ReviewDto reviewDto);
        void CreateUserInfo(UserInfoDto userInfoDto);
        UserInfoDto GetUserInfo(int? id);
        IEnumerable<ArticleDto> GetArticles();
        IEnumerable<ReviewDto> GetReviewes();
        void Dispose();
    }
}
