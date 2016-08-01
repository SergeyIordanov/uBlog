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
        public DbSet<Tag> Tags { get; set; }

        static BlogContext()
        {
            Database.SetInitializer(new BlogDbInitializer());
        }

        public BlogContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany(c => c.Tags)
                .WithMany(s => s.Articles)
                .Map(t => t.MapLeftKey("ArticleId")
                .MapRightKey("TagId")
                .ToTable("ArticleTag"));
        }
    }
}
