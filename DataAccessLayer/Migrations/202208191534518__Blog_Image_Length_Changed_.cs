namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Blog_Image_Length_Changed_ : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 100));
        }
    }
}
