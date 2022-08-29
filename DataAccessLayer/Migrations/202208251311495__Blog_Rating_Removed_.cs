namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Blog_Rating_Removed_ : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "BlogRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogRating", c => c.Int(nullable: false));
        }
    }
}
