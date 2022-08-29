namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _About_Annotation_Removed_forFluentValidation_ : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutContent1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutContent2", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutContent2", c => c.String(maxLength: 500));
            AlterColumn("dbo.Abouts", "AboutContent1", c => c.String(maxLength: 500));
        }
    }
}
