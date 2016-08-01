using System;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    public class BlogUnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _db;
        private ArticleRepository _articleRepository;
        private ReviewRepository _reviewRepository;
        private UserInfoRepository _userInfoRepository;
        private QuestionRepository _questionRepository;
        private AnswerRepository _answerRepository;
        private TagRepository _tagRepository;

        public BlogUnitOfWork(string connectionString)
        {
            _db = new BlogContext(connectionString);
        }

        public IRepository<Article> Articles 
            => _articleRepository ?? (_articleRepository = new ArticleRepository(_db));

        public IRepository<Review> Reviewes 
            => _reviewRepository ?? (_reviewRepository = new ReviewRepository(_db));

        public IRepository<UserInfo> UserInfoes
            => _userInfoRepository ?? (_userInfoRepository = new UserInfoRepository(_db));

        public IRepository<Question> Questions
            => _questionRepository ?? (_questionRepository = new QuestionRepository(_db));

        public IRepository<Answer> Answers
            => _answerRepository ?? (_answerRepository = new AnswerRepository(_db));

        public IRepository<Tag> Tags
            => _tagRepository ?? (_tagRepository = new TagRepository(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
