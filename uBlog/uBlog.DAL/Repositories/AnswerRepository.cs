using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    class AnswerRepository : IRepository<Answer>
    {
        private BlogContext db;

        public AnswerRepository(BlogContext context)
        {
            db = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return db.Answers;
        }

        public Answer Get(int id)
        {
            return db.Answers.Find(id);
        }

        public IEnumerable<Answer> Find(Func<Answer, bool> predicate)
        {
            return db.Answers.Where(predicate).ToList();
        }

        public void Create(Answer answer)
        {
            db.Answers.Add(answer);
        }

        public void Update(Answer answer)
        {
            db.Entry(answer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var answer = db.Answers.Find(id);
            if (answer != null)
                db.Answers.Remove(answer);
        }
    }
}
