namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Blog_Status_Added_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogStatus");
        }
    }
}
