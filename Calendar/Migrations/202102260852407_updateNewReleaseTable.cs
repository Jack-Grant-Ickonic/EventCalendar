namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNewReleaseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewReleases", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.NewReleases", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.NewReleases", "IsFullDay", c => c.Boolean(nullable: false));
            DropColumn("dbo.NewReleases", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewReleases", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.NewReleases", "IsFullDay");
            DropColumn("dbo.NewReleases", "EndDate");
            DropColumn("dbo.NewReleases", "StartDate");
        }
    }
}
