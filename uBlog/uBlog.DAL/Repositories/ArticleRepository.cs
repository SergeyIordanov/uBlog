using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Interfaces;
using uBlog.Entities.BlogEntities;

namespace uBlog.DAL.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly BlogContext _db;

        public ArticleRepository(BlogContext context)
        {
            _db = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return _db.Articles.ToList();
        }

        public Article Get(int id)
        {            
            return _db.Articles.Find(id);
        }

        public void Create(Article article)
        {
            _db.Articles.Add(article);
        }

        public void Update(Article article)
        {
            //db.Entry(article).State = EntityState.Modified;
            var original = _db.Articles.Find(article.ArticleId);
            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(article);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return _db.Articles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var article = _db.Articles.Find(id);
            if (article != null)
                _db.Articles.Remove(article);
        }
    }
}
