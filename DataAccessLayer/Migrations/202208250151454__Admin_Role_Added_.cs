namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Admin_Role_Added_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Role", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Role");
        }
    }
}
