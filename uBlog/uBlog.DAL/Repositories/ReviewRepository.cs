using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        private readonly BlogContext _db;

        public ReviewRepository(BlogContext context)
        {
            _db = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return _db.Reviewes;
        }

        public Review Get(int id)
        {
            return _db.Reviewes.Find(id);
        }

        public void Create(Review review)
        {
            _db.Reviewes.Add(review);
        }

        public void Update(Review review)
        {
            _db.Entry(review).State = EntityState.Modified;
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return _db.Reviewes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Review review = _db.Reviewes.Find(id);
            if (review != null)
                _db.Reviewes.Remove(review);
        }
    }
}
