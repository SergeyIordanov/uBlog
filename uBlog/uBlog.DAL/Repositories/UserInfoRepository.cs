using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    public class UserInfoRepository : IRepository<UserInfo>
    {
        private BlogContext db;

        public UserInfoRepository(BlogContext context)
        {
            db = context;
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return db.UserInfoes;
        }

        public UserInfo Get(int id)
        {
            return db.UserInfoes.Find(id);
        }

        public void Create(UserInfo userInfo)
        {
            db.UserInfoes.Add(userInfo);
        }

        public void Update(UserInfo userInfo)
        {
            db.Entry(userInfo).State = EntityState.Modified;
        }

        public IEnumerable<UserInfo> Find(Func<UserInfo, bool> predicate)
        {
            return db.UserInfoes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo != null)
                db.UserInfoes.Remove(userInfo);
        }
    }
}
