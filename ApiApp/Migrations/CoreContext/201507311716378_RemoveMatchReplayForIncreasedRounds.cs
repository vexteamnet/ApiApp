namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMatchReplayForIncreasedRounds : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Matches");
            AddPrimaryKey("dbo.Matches", new[] { "EventSku", "DivisionName", "Round", "Instance", "Number" });
            DropColumn("dbo.Matches", "Replay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "Replay", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Matches");
            AddPrimaryKey("dbo.Matches", new[] { "EventSku", "DivisionName", "Round", "Instance", "Number", "Replay" });
        }
    }
}
