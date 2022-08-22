namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Author_Title_and_AboutShort_Added_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Authors", "AuthorAboutShort", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorAboutShort");
            DropColumn("dbo.Authors", "AuthorTitle");
        }
    }
}
