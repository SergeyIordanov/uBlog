using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private BlogContext db;

        public ArticleRepository(BlogContext context)
        {
            db = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles;
        }

        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }

        public void Create(Article article)
        {
            db.Articles.Add(article);
        }

        public void Update(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
        }

        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return db.Articles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var article = db.Articles.Find(id);
            if (article != null)
                db.Articles.Remove(article);
        }
    }
}
