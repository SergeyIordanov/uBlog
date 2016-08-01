using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.DAL.EF;
using uBlog.DAL.Entities;
using uBlog.DAL.Interfaces;

namespace uBlog.DAL.Repositories
{
    class QuestionRepository : IRepository<Question>
    {

        private readonly BlogContext _db;

        public QuestionRepository(BlogContext context)
        {
            _db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return _db.Questions;
        }

        public Question Get(int id)
        {
            return _db.Questions.Find(id);
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return _db.Questions.Where(predicate).ToList();
        }

        public void Create(Question question)
        {
            _db.Questions.Add(question);
        }

        public void Update(Question question)
        {
            //db.Entry(question).State = EntityState.Modified;
            var original = _db.Questions.Find(question.QuestionId);
            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(question);
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var question = _db.Questions.Find(id);
            if (question != null)
                _db.Questions.Remove(question);
        }
    }
}
