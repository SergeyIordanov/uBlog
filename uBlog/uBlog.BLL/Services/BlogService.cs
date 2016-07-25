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

        public void CreateArticle(ArticleDTO articleDTO)
        {
            if(articleDTO == null)
                throw new ValidationException("Cannot create article from null", "");
            if (articleDTO.Text == null)
                throw new ValidationException("This property cannot be null", "Text");
            if (articleDTO.Title == null)
                throw new ValidationException("This property cannot be null", "Title");
            if (articleDTO.PublishDate == null)
                throw new ValidationException("This property cannot be null", "PublishDate");
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, Article>());
            var article = Mapper.Map<Article>(articleDTO);
            Database.Articles.Create(article);
            Database.Save();
        }

        public void CreateReview(ReviewDTO reviewDTO)
        {
            if (reviewDTO == null)
                throw new ValidationException("Cannot create article from null", "");
            if (reviewDTO.Text == null)
                throw new ValidationException("This property cannot be null", "Text");
            if (reviewDTO.AuthorName == null)
                throw new ValidationException("This property cannot be null", "AuthorName");
            if (reviewDTO.PublishDate == null)
                throw new ValidationException("This property cannot be null", "PublishDate");
            Mapper.Initialize(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var review = Mapper.Map<Review>(reviewDTO);
            Database.Reviewes.Create(review);
            Database.Save();
        }

        public void CreateUserInfo(UserInfoDTO userInfoDTO)
        {
            if (userInfoDTO == null)
                throw new ValidationException("Cannot create article from null", "");
            if (userInfoDTO.Email == null)
                throw new ValidationException("This property cannot be null", "Email");
            if (userInfoDTO.FirstName == null)
                throw new ValidationException("This property cannot be null", "FirstName");
            if (userInfoDTO.Gender == null)
                throw new ValidationException("This property cannot be null", "Gender");
            if (userInfoDTO.LastName == null)
                throw new ValidationException("This property cannot be null", "LastName");
            Mapper.Initialize(cfg => cfg.CreateMap<UserInfoDTO, UserInfo>());
            var userInfo = Mapper.Map<UserInfo>(userInfoDTO);
            Database.UserInfoes.Create(userInfo);
            Database.Save();
        }


        public IEnumerable<ArticleDTO> GetArticles()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDTO>());
            return Mapper.Map<IEnumerable<ArticleDTO>>(Database.Articles.GetAll());
        }

        public IEnumerable<ReviewDTO> GetReviewes()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Review, ReviewDTO>());
            return Mapper.Map<IEnumerable<ReviewDTO>>(Database.Reviewes.GetAll());
        }

        public UserInfoDTO GetUserInfo(int? id)
        {
            if (id == null)
                throw new ValidationException("UserInfo's id wasn't set", "");
            var userInfo = Database.UserInfoes.Get(id.Value);
            if (userInfo == null)
                throw new ValidationException("UserInfo wasn't found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<UserInfo, UserInfoDTO>());
            return Mapper.Map<UserInfoDTO>(userInfo);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
