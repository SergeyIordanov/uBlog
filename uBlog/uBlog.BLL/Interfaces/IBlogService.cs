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
        QuestionDto GetQuestion(int? id);
        ArticleDto GetArticle(int? id);

        void UpdateAnswer(AnswerDto answerDto);

        void DeleteArticle(int? id);
        void DeleteReview(int? id);

        IEnumerable<ArticleDto> GetArticles();
        IEnumerable<ReviewDto> GetReviewes();
        void Dispose();
    }
}
