using AutoMapper;
using System.Collections.Generic;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.BLL.Services
{
    public class BlogService : IBlogService
    {
        IUnitOfWork Database { get; set; }

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
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDto, Article>());
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
            Mapper.Initialize(cfg => cfg.CreateMap<UserInfoDto, UserInfo>());
            var userInfo = Mapper.Map<UserInfo>(userInfoDto);
            Database.UserInfoes.Create(userInfo);
            Database.Save();
        }


        public IEnumerable<ArticleDto> GetArticles()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDto>());
            return Mapper.Map<IEnumerable<ArticleDto>>(Database.Articles.GetAll());
        }

        public IEnumerable<ReviewDto> GetReviewes()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Review, ReviewDto>());
            return Mapper.Map<IEnumerable<ReviewDto>>(Database.Reviewes.GetAll());
        }

        public UserInfoDto GetUserInfo(int? id)
        {
            if (id == null)
                throw new ValidationException("UserInfo's id wasn't set", "");
            var userInfo = Database.UserInfoes.Get(id.Value);
            if (userInfo == null)
                throw new ValidationException("UserInfo wasn't found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<UserInfo, UserInfoDto>());
            return Mapper.Map<UserInfoDto>(userInfo);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
