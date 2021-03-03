namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFullDay : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NewReleases", "IsFullDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewReleases", "IsFullDay", c => c.Boolean(nullable: false));
        }
    }
}
