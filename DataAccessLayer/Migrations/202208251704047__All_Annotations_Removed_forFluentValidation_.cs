namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _All_Annotations_Removed_forFluentValidation_ : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Authors", new[] { "AuthorMail" });
            AlterColumn("dbo.Admins", "UserName", c => c.String());
            AlterColumn("dbo.Admins", "Role", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Authors", "AuthorName", c => c.String());
            AlterColumn("dbo.Authors", "AuthorSurname", c => c.String());
            AlterColumn("dbo.Authors", "AuthorMail", c => c.String());
            AlterColumn("dbo.Authors", "AuthorPassword", c => c.String());
            AlterColumn("dbo.Authors", "AuthorTitle", c => c.String());
            AlterColumn("dbo.Authors", "AuthorAboutShort", c => c.String());
            AlterColumn("dbo.Authors", "AuthorImage", c => c.String());
            AlterColumn("dbo.Authors", "AuthorAbout", c => c.String());
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String());
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String());
            AlterColumn("dbo.Blogs", "BlogContent", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryColor", c => c.String());
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String());
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
            AlterColumn("dbo.Comments", "CommentMail", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
            AlterColumn("dbo.Contacts", "SurName", c => c.String());
            AlterColumn("dbo.Contacts", "Mail", c => c.String());
            AlterColumn("dbo.Contacts", "Subject", c => c.String());
            AlterColumn("dbo.Contacts", "Message", c => c.String());
            AlterColumn("dbo.SubscribeMails", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubscribeMails", "Mail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Subject", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Mail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "SurName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comments", "CommentMail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Categories", "CategoryColor", c => c.String(maxLength: 7));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Blogs", "BlogContent", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 250));
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Authors", "AuthorAbout", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Authors", "AuthorImage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Authors", "AuthorAboutShort", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Authors", "AuthorTitle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "AuthorPassword", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Authors", "AuthorMail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "AuthorSurname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Admins", "Role", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Admins", "UserName", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Authors", "AuthorMail", unique: true);
        }
    }
}
