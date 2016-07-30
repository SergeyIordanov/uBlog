using System.Data.Entity;
using uBlog.DAL.Entities;

namespace uBlog.DAL.EF
{
    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviewes { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        static BlogContext()
        {
            Database.SetInitializer(new BlogDbInitializer());
        }

        public BlogContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
