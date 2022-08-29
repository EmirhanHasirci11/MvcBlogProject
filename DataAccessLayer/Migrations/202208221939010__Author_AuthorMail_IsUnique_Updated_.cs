namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Author_AuthorMail_IsUnique_Updated_ : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Authors", "AuthorMail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", new[] { "AuthorMail" });
        }
    }
}
