namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEventVenueAndContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Venue_Name", c => c.String());
            AddColumn("dbo.Events", "Venue_Address", c => c.String());
            AddColumn("dbo.Events", "Venue_Region", c => c.String());
            AddColumn("dbo.Events", "Venue_Country", c => c.String());
            AddColumn("dbo.Events", "Contact_Name", c => c.String());
            AddColumn("dbo.Events", "Contact_Title", c => c.String());
            AddColumn("dbo.Events", "Contact_Email", c => c.String());
            AddColumn("dbo.Events", "Contact_Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Contact_Phone");
            DropColumn("dbo.Events", "Contact_Email");
            DropColumn("dbo.Events", "Contact_Title");
            DropColumn("dbo.Events", "Contact_Name");
            DropColumn("dbo.Events", "Venue_Country");
            DropColumn("dbo.Events", "Venue_Region");
            DropColumn("dbo.Events", "Venue_Address");
            DropColumn("dbo.Events", "Venue_Name");
        }
    }
}
