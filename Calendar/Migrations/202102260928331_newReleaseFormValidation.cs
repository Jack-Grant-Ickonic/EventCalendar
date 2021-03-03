namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newReleaseFormValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewReleases", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.NewReleases", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewReleases", "Description", c => c.String());
            AlterColumn("dbo.NewReleases", "Title", c => c.String());
        }
    }
}
