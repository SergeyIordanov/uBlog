using System;
using System.Data.Entity;
using uBlog.DAL.Entities;

namespace uBlog.DAL.EF
{
    public class BlogDbInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext db)
        {
            db.Articles.AddRange(new Article[] {
                new Article()
                {
                    ArticleId = 1,
                    Title = "The First Article",
                    Text = "Dear Readers,\r\nWe are glad to see you in our minimalistic blog calling 'uBlog'!\r\n" +
                        "It's the first step in our long fantastic journey. Hope you'll stay with us!\r\n\r\nGood luck!",
                    PublishDate = DateTime.UtcNow.AddHours(-5)
                },
                new Article()
                {
                    ArticleId = 2,
                    Title = "Hot News!",
                    Text = "Hello, everybody!\r\nI just need to say you that I'am the only one person who reads this articles.. and writes it.\r\n" +
                        "Maybe I should rename this blog for 'uDiary'? Or it's just a schizophrenia?\r\n\r\nAnyway, stay awesome, bros!",
                    PublishDate = DateTime.UtcNow.AddHours(-3)
                },
                new Article()
                {
                    ArticleId = 3,
                    Title = "Very Interesting Article",
                    Text = "Hi, guys!\r\nThis article was writen just for testing 'uBlog'. There is no usefull information for you, " +
                        "but we need at least three articles to be sure that our blog is exactly the same like we saw it!\r\n\r\nStay awesome, bros!",
                    PublishDate = DateTime.UtcNow.AddHours(-2)
                },
            });

            db.Reviewes.AddRange(new Review[] {
                new Review {
                    ReviewId = 1,
                    AuthorName = "Arthur",
                    Text = "Hi! Found a lot of intresting things here. Thanks)",
                    PublishDate = DateTime.UtcNow.AddHours(-6)
                },
                new Review {
                    ReviewId = 2,
                    AuthorName = "Ann",
                    Text = "Hey!\r\nWhat are you talking about?? Just lost my time!",
                    PublishDate = DateTime.UtcNow.AddHours(-5)
                },
                new Review {
                    ReviewId = 3,
                    AuthorName = "Bob",
                    Text = "Wow, nice design! Is it a standard colors from materialize?\r\nThink different;)",
                    PublishDate = DateTime.UtcNow.AddHours(-4)
                },
            });

            db.SaveChanges();
        }
    }
}
