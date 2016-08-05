using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using uBlog.BLL.DataTransferObjects;
using uBlog.BLL.Infrastructure;
using uBlog.BLL.Interfaces;
using uBlog.DAL.Interfaces;
using uBlog.Entities.BlogEntities;

namespace uBlog.BLL.Services
{
    public class BlogService : IBlogService
    {
        IUnitOfWork Database { get; }

        public BlogService(IUnitOfWork uow)
        {
            Database = uow;
        }

        #region Create

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
                cfg.CreateMap<ArticleDto, Article>().ForMember(a => a.Tags, o => o.Ignore());
            });
            var article = Mapper.Map<Article>(articleDto);

            var allTags = Database.Tags.GetAll().ToList();
            foreach (var tag in articleDto.Tags)
            {
                var newTag = new Tag { Text = tag };
                if (allTags.Find(x => x.Text.Equals(newTag.Text)) != null)
                {
                    article.Tags.Add(allTags.First(x => x.Text.Equals(newTag.Text)));
                }
                else
                {
                    Database.Tags.Create(newTag);
                    article.Tags.Add(newTag);                   
                }
            }

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

        #endregion

        #region Get

        public IEnumerable<ArticleDto> GetArticles()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDto>().ForMember(a => a.Tags, o => o.Ignore());
            });
            var mapper = config.CreateMapper();
            var articles = Database.Articles.GetAll().ToList();
            var articlesDto = mapper.Map<IEnumerable<ArticleDto>>(Database.Articles.GetAll()).ToList();
            for (int i = 0; i < articles.Count(); i++)
            {
                foreach (var tag in articles[i].Tags)
                {
                    articlesDto[i].Tags.Add(tag.Text);
                }
            }

            return articlesDto;
        }

        public IEnumerable<ArticleDto> GetArticles(string tagName)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDto>().ForMember(a => a.Tags, o => o.Ignore());
            });
            var mapper = config.CreateMapper();

            var tag = Database.Tags.Find(x => x.Text.Equals(tagName)).FirstOrDefault();

            if (tag == null)
                return new List<ArticleDto>();

            var articlesDto = mapper.Map<IEnumerable<ArticleDto>>(tag.Articles.ToList()).ToList();
            for (int i = 0; i < tag.Articles.ToList().Count(); i++)
            {
                foreach (var innerTag in tag.Articles.ToList()[i].Tags)
                {
                    articlesDto[i].Tags.Add(innerTag.Text);
                }
            }

            return articlesDto;
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
                cfg.CreateMap<Article, ArticleDto>().ForMember(a => a.Tags, o => o.Ignore());
            });
            var mapper = config.CreateMapper();
            var articleDto = mapper.Map<Article, ArticleDto>(article);
            foreach (var tag in article.Tags)
            {
                articleDto.Tags.Add(tag.Text);
            }
            return articleDto;
        }

        #endregion

        #region Update

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

        #endregion

        #region Delete

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

        #endregion

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
