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
        private BlogContext db;

        public ReviewRepository(BlogContext context)
        {
            db = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Reviewes;
        }

        public Review Get(int id)
        {
            return db.Reviewes.Find(id);
        }

        public void Create(Review review)
        {
            db.Reviewes.Add(review);
        }

        public void Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return db.Reviewes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Review review = db.Reviewes.Find(id);
            if (review != null)
                db.Reviewes.Remove(review);
        }
    }
}
