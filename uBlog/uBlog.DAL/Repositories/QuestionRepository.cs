using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    class QuestionRepository : IRepository<Question>
    {

        private BlogContext db;

        public QuestionRepository(BlogContext context)
        {
            db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }

        public Question Get(int id)
        {
            return db.Questions.Find(id);
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return db.Questions.Where(predicate).ToList();
        }

        public void Create(Question question)
        {
            db.Questions.Add(question);
        }

        public void Update(Question question)
        {
            db.Entry(question).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var question = db.Questions.Find(id);
            if (question != null)
                db.Questions.Remove(question);
        }
    }
}
