using System;
using System.Collections.Generic;
using System.Data.Entity;
using uBlog.Entities.BlogEntities;

namespace uBlog.DAL.EF
{
    public class BlogDbInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext db)
        {
            var tags = new List<Tag>
            {
                new Tag {TagId = 1, Text = "thoughts"},
                new Tag {TagId = 2, Text = "C#"},
                new Tag {TagId = 3, Text = ".NET"},
                new Tag {TagId = 4, Text = "Microsoft"},
                new Tag {TagId = 5, Text = "blog"},
                new Tag {TagId = 6, Text = "news"},
                new Tag {TagId = 7, Text = "greatings"},
                new Tag {TagId = 8, Text = "test"},
                new Tag {TagId = 9, Text = "it"}
            };

            db.Tags.AddRange(tags);

            db.Articles.AddRange(new[] {
                new Article()
                {
                    ArticleId = 1,
                    Title = "The First Article",
                    Text = "Dear Readers,\r\nWe are glad to see you in our minimalistic blog calling 'uBlog'!\r\n" +
                        "It's the first step in our long fantastic journey. Hope you'll stay with us!\r\n\r\nGood luck!",
                    PublishDate = DateTime.UtcNow.AddHours(-5),
                    Tags = new List<Tag> { tags[7], tags[6], tags[4] }
                },
                new Article()
                {
                    ArticleId = 2,
                    Title = "Hot News!",
                    Text = "Hello, everybody!\r\nI just need to say you that I'am the only one person who reads this articles.. and writes it.\r\n" +
                        "Maybe I should rename this blog for 'uDiary'? Or it's just a schizophrenia?\r\n\r\nAnyway, stay awesome, bros!",
                    PublishDate = DateTime.UtcNow.AddHours(-3),
                    Tags = new List<Tag> { tags[0], tags[5], tags[4], tags[7] }
                },
                new Article()
                {
                    ArticleId = 3,
                    Title = "Very Interesting Article",
                    Text = "Hi, guys!\r\nThis article was writen just for testing 'uBlog'. There is no usefull information for you, " +
                        "but we need at least three articles to be sure that our blog is exactly the same like we saw it!\r\n\r\nStay awesome, bros!",
                    PublishDate = DateTime.UtcNow.AddHours(-2),
                    Tags = new List<Tag> {tags[5], tags[4], tags[7] }
                },
                new Article()
                {
                    ArticleId = 4,
                    Title = "NET Core Version 1 Released - So What?",
                    Text =
                        "In some senses this is a momentous event - Microsoft has a Version 1 of the cross-platform open source .NET Core. But is it momentous more because of the change in approach it signals, or is there some real value in it. In short, should you rush out and install .NET Core?\r\n" +
                        "Mostly the answer is probably not.\r\n\r\nThere are some programmers who want to do exactly what .NET Core is designed for and for these it is an exciting time.For the average programmer, it is difficult to see where the revolution would lead and why anyone would want to follow\r\n" +
                        "Version1.0 of.NET core is a cross - platform basic library for .NET applications.It supports all of the standard.NET languages - C#, VB, F# and C++. You can write programs that will run under Windows, OS X, Linux and with Xamarin iOS. It is supported by Red Hat and, in fact, under Linux the Red Hat implementation is the standard.\r\n" +
                        "It is composed of the.NET Runtime which will run compiled MSIL code; a framework library that provides primitive data types etc; a set of SDK tools - compilers etc; and a loader.\r\n" +
                        "In many ways .NET Core doesn't even provide as much infrastructure as Mono, the first open source port of .NET, did and still does. The Mono project even had an open source version of Silverlight - something that isn't likely to happen in the official open source project." +
                        "\r\nSo isn't the ability to run .NET programs on just about any platform that matters (note: BSD Unix seems to be missing) an important opportunity?" +
                        "\r\nThe big problem is that there is no common UI." +
                        "\r\nMicrosoft hasn't, and isn't likely to open source Win Forms or WPF and who knows what dependencies Universal Apps have.The big problem is that Win Forms needs Windows and there rest need DirectX which are only available on Windows." +
                        "\r\nWhat this means is that if you are targeting .NET core then the only sort of cross-platform applications you can write are console apps - and not many programmers want to write console apps.  This is the reason that the.NET Blog says:" +
                        "\r\n\r\n\".NET Core is a cross-platform, open source, and modular .NET platform for creating modern web apps, microservices, libraries and console applications.\"" +
                        "\r\n\r\nThe web apps reference really means in conjunction with ASP.NET Core 1, which has also just been released. This is great if you are working on a brand new MVC- style ASP app, but not if you have a legacy Web Forms ASP .NET app. While there are some enthusiastic people excited by the new way of doing Microsoft - style websites, it is difficult to see why a this is preferable to other approaches unless you are already a Microsoft shop, and even in this case it is a young technology that might not be a good bet for the future." +
                        "\r\nIf you don't buy into the new ASP.NET you can create microservices, libraries and console apps - well that's still a minority.Most apps need a GUI of some description and this is currently what is lacking.There is no cross platform GUI for .NET Core except for Xamarin Forms, which is another unknown technology for most Microsoft programmers." +
                        "\r\nThe bottom line is that.NET Core is a step in the progress of the Open Sourcing of selected Microsoft technologies and as such we should celebrate." +
                        "\r\nShould you rush off, download it and get programming ?" +
                        "\r\nProbably not.",
                    PublishDate = DateTime.UtcNow.AddHours(-2),
                    Tags = new List<Tag> {tags[5], tags[1], tags[2], tags[3], tags[8] }
                },
            });

            db.Reviewes.AddRange(new[] {
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

            db.Questions.Add(new Question
            {
                QuestionId = 1,
                Text = "What is your favourite programming language?"
            });

            db.Answers.AddRange(new[]
            {
                new Answer
                {
                    Text = "C#",
                    QuestionId = 1,
                    AnswerId = 1,
                    VotesCount = 5
                },
                new Answer
                {
                    Text = "Java",
                    QuestionId = 1,
                    AnswerId = 2,
                    VotesCount = 3
                },
                new Answer
                {
                    Text = "C++",
                    QuestionId = 1,
                    AnswerId = 3,
                    VotesCount = 4
                },
                new Answer
                {
                    Text = "PHP",
                    QuestionId = 1,
                    AnswerId = 4,
                    VotesCount = 1
                },
            });

            db.SaveChanges();
        }
    }
}
