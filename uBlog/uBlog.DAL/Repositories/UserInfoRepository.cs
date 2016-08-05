using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Interfaces;
using uBlog.Entities.BlogEntities;

namespace uBlog.DAL.Repositories
{
    public class UserInfoRepository : IRepository<UserInfo>
    {
        private readonly BlogContext _db;

        public UserInfoRepository(BlogContext context)
        {
            _db = context;
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return _db.UserInfoes;
        }

        public UserInfo Get(int id)
        {
            return _db.UserInfoes.Find(id);
        }

        public void Create(UserInfo userInfo)
        {
            _db.UserInfoes.Add(userInfo);
        }

        public void Update(UserInfo userInfo)
        {
            //_db.Entry(userInfo).State = EntityState.Modified;
            var original = _db.UserInfoes.Find(userInfo.UserInfoId);
            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(userInfo);
                _db.SaveChanges();
            }
        }

        public IEnumerable<UserInfo> Find(Func<UserInfo, bool> predicate)
        {
            return _db.UserInfoes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UserInfo userInfo = _db.UserInfoes.Find(id);
            if (userInfo != null)
                _db.UserInfoes.Remove(userInfo);
        }
    }
}
