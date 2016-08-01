﻿using System;
using uBlog.DAL.Entities;

namespace uBlog.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Review> Reviewes { get; }
        IRepository<UserInfo> UserInfoes { get; }
        IRepository<Question> Questions { get; }
        IRepository<Answer> Answers { get; }
        IRepository<Tag> Tags { get; }

        void Save();
    }
}
