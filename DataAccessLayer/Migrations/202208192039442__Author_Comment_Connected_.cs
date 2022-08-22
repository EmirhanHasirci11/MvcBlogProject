namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Author_Comment_Connected_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorMail", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Authors", "AuthorPassword", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Comments", "CommentMail", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Comments", "CommentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "AuthorID", c => c.Int());
            CreateIndex("dbo.Comments", "AuthorID");
            AddForeignKey("dbo.Comments", "AuthorID", "dbo.Authors", "AuthorID");
            DropColumn("dbo.Comments", "UserName");
            DropColumn("dbo.Comments", "Mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Mail", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Comments", "UserName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Comments", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Comments", new[] { "AuthorID" });
            DropColumn("dbo.Comments", "AuthorID");
            DropColumn("dbo.Comments", "CommentDate");
            DropColumn("dbo.Comments", "CommentMail");
            DropColumn("dbo.Authors", "AuthorPassword");
            DropColumn("dbo.Authors", "AuthorMail");
        }
    }
}
