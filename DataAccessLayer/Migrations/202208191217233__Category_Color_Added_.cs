namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Category_Color_Added_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryColor", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryColor");
        }
    }
}
