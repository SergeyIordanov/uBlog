namespace uBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Text = c.String(),
                        VotesCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        Text = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserInfoId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        About = c.String(),
                        Interest = c.String(),
                        IsSubscribed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserInfoId);
            
            CreateTable(
                "dbo.ArticleTag",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.TagId })
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ArticleTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ArticleTag", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleTag", new[] { "TagId" });
            DropIndex("dbo.ArticleTag", new[] { "ArticleId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.ArticleTag");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Reviews");
            DropTable("dbo.Questions");
            DropTable("dbo.Tags");
            DropTable("dbo.Articles");
            DropTable("dbo.Answers");
        }
    }
}
