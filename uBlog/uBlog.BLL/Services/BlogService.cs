using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.BLL.Services
{
    public class BlogService : IBlogService
    {
        IUnitOfWork Database { get; }

        public BlogService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateArticle(ArticleDto articleDto)
        {
            if(articleDto == null)
                throw new ValidationException("Cannot create article from null", "");
            if (articleDto.Text == null)
                throw new ValidationException("This property cannot be null", "Text");
            if (articleDto.Title == null)
                throw new ValidationException("This property cannot be null", "Title");
            if (articleDto.PublishDate == null)
                throw new ValidationException("This property cannot be null", "PublishDate");
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ArticleDto, Article>();
                cfg.CreateMap<TagDto, Tag>();
            });
            var article = Mapper.Map<Article>(articleDto);
            Database.Articles.Create(article);
            Database.Save();
        }

        public void CreateReview(ReviewDto reviewDto)
        {
            if (reviewDto == null)
                throw new ValidationException("Cannot create article from null", "");
            if (reviewDto.Text == null)
                throw new ValidationException("This property cannot be null", "Text");
            if (reviewDto.AuthorName == null)
                throw new ValidationException("This property cannot be null", "AuthorName");
            if (reviewDto.PublishDate == null)
                throw new ValidationException("This property cannot be null", "PublishDate");
            Mapper.Initialize(cfg => cfg.CreateMap<ReviewDto, Review>());
            var review = Mapper.Map<Review>(reviewDto);
            Database.Reviewes.Create(review);
            Database.Save();
        }

        public void CreateUserInfo(UserInfoDto userInfoDto)
        {
            if (userInfoDto == null)
                throw new ValidationException("Cannot create article from null", "");
            if (userInfoDto.Email == null)
                throw new ValidationException("This property cannot be null", "Email");
            if (userInfoDto.FirstName == null)
                throw new ValidationException("This property cannot be null", "FirstName");
            if (userInfoDto.Gender == null)
                throw new ValidationException("This property cannot be null", "Gender");
            if (userInfoDto.LastName == null)
                throw new ValidationException("This property cannot be null", "LastName");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfoDto, UserInfo>());
            var mapper = config.CreateMapper();
            var userInfo = mapper.Map<UserInfo>(userInfoDto);

            Database.UserInfoes.Create(userInfo);
            Database.Save();
        }       

        public IEnumerable<ArticleDto> GetArticles()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDto>();
                cfg.CreateMap<Tag, TagDto>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ArticleDto>>(Database.Articles.GetAll());
        }

        public IEnumerable<ReviewDto> GetReviewes()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDto>());
            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ReviewDto>>(Database.Reviewes.GetAll());
        }

        public UserInfoDto GetUserInfo(int? id)
        {
            if (id == null)
                throw new ValidationException("UserInfo's id wasn't set", "");
            var userInfo = Database.UserInfoes.Get(id.Value);
            if (userInfo == null)
                throw new ValidationException("UserInfo wasn't found", "");
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, UserInfoDto>());
            var mapper = config.CreateMapper();
            return mapper.Map<UserInfoDto>(userInfo);
        }

        public QuestionDto GetQuestion(int? id)
        {
            if (id == null)
                throw new ValidationException("Question's id wasn't set", "");
            var question = Database.Questions.Get(id.Value);
            if (question == null)
                throw new ValidationException("Question wasn't found", "");

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Question, QuestionDto>();
                cfg.CreateMap<Answer, AnswerDto>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<Question, QuestionDto>(question);
        }

        public ArticleDto GetArticle(int? id)
        {
            if (id == null)
                throw new ValidationException("Article's id wasn't set", "");
            var article = Database.Articles.Get(id.Value);
            if (article == null)
                throw new ValidationException("Article wasn't found", "");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDto>();
                cfg.CreateMap<Tag, TagDto>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<Article, ArticleDto>(article);
        }

        public void UpdateAnswer(AnswerDto answerDto)
        {
            if(Database.Answers.Get(answerDto.AnswerId) == null)
                throw new ValidationException("Answer wasn't found", "");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDto, Answer>());
            var mapper = config.CreateMapper();
            var answer = mapper.Map<Answer>(answerDto);

            Database.Answers.Update(answer);

            Database.Save();
        }

        public void DeleteArticle(int? id)
        {
            if (id == null)
                throw new ValidationException("Id is null", "");
            if (!Database.Articles.Find(x => x.ArticleId == id).Any())
                throw new ValidationException("Article wasn't found", "");
            Database.Articles.Delete((int)id);
            Database.Save();
        }

        public void DeleteReview(int? id)
        {
            if (id == null)
                throw new ValidationException("Id is null", "");
            if (!Database.Reviewes.Find(x => x.ReviewId == id).Any())
                throw new ValidationException("Review wasn't found", "");
            Database.Reviewes.Delete((int)id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
