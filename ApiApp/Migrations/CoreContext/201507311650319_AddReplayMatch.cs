namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReplayMatch : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Matches");
            AddColumn("dbo.Matches", "Replay", c => c.Int(nullable: false, defaultValue: 0));
            AddPrimaryKey("dbo.Matches", new[] { "EventSku", "DivisionName", "Round", "Instance", "Number", "Replay" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Matches");
            DropColumn("dbo.Matches", "Replay");
            AddPrimaryKey("dbo.Matches", new[] { "EventSku", "DivisionName", "Round", "Instance", "Number" });
        }
    }
}
