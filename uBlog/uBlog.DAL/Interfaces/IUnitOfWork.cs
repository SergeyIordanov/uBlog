using System;
using uBlog.DAL.Entities;

namespace uBlog.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Review> Reviewes { get; }
        IRepository<UserInfo> UserInfoes { get; }

        void Save();
    }
}
