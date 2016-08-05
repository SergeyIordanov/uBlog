using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Interfaces;
using uBlog.Entities.BlogEntities;

namespace uBlog.DAL.Repositories
{
    class AnswerRepository : IRepository<Answer>
    {
        private readonly BlogContext _db;

        public AnswerRepository(BlogContext context)
        {
            _db = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _db.Answers;
        }

        public Answer Get(int id)
        {
            return _db.Answers.Find(id);
        }

        public IEnumerable<Answer> Find(Func<Answer, bool> predicate)
        {
            return _db.Answers.Where(predicate).ToList();
        }

        public void Create(Answer answer)
        {
            _db.Answers.Add(answer);
        }

        public void Update(Answer answer)
        {
            //db.Entry(answer).State = EntityState.Modified;
            var original = _db.Answers.Find(answer.AnswerId);
            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(answer);
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var answer = _db.Answers.Find(id);
            if (answer != null)
                _db.Answers.Remove(answer);
        }
    }
}
