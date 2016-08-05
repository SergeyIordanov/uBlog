using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Interfaces;
using uBlog.Entities.BlogEntities;

namespace uBlog.DAL.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly BlogContext _db;

        public TagRepository(BlogContext context)
        {
            _db = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _db.Tags.ToList();
        }

        public Tag Get(int id)
        {
            return _db.Tags.Find(id);
        }

        public void Create(Tag tag)
        {
            _db.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            //_db.Entry(review).State = EntityState.Modified;
            var original = _db.Tags.Find(tag.TagId);
            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(tag);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            return _db.Tags.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var tag = _db.Tags.Find(id);
            if (tag != null)
                _db.Tags.Remove(tag);
        }
    }
}
