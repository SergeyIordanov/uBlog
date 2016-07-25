using System;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    public class BlogUnitOfWork : IUnitOfWork
    {
        private BlogContext db;
        private ArticleRepository articleRepository;
        private ReviewRepository reviewRepository;
        private UserInfoRepository userInfoRepository;

        public BlogUnitOfWork(string connectionString)
        {
            db = new BlogContext(connectionString);
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }

        public IRepository<Review> Reviewes
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(db);
                return reviewRepository;
            }
        }

        public IRepository<UserInfo> UserInfoes
        {
            get
            {
                if (userInfoRepository == null)
                    userInfoRepository = new UserInfoRepository(db);
                return userInfoRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
