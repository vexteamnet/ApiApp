namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventVenueCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Venue_City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Venue_City");
        }
    }
}
