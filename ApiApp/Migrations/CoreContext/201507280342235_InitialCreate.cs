namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        EventSku = c.String(nullable: false, maxLength: 17),
                        Name = c.String(nullable: false, maxLength: 128),
                        TeamNumber = c.String(nullable: false, maxLength: 5),
                        QualifiesFor_Sku = c.String(maxLength: 17),
                    })
                .PrimaryKey(t => new { t.EventSku, t.Name, t.TeamNumber })
                .ForeignKey("dbo.Events", t => t.EventSku, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.QualifiesFor_Sku)
                .ForeignKey("dbo.Teams", t => t.TeamNumber, cascadeDelete: true)
                .Index(t => t.EventSku)
                .Index(t => t.TeamNumber)
                .Index(t => t.QualifiesFor_Sku);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Sku = c.String(nullable: false, maxLength: 17),
                        Name = c.String(),
                        Program = c.Int(nullable: false),
                        Levels = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                        Season = c.String(),
                        Description = c.String(),
                        Agenda = c.String(),
                    })
                .PrimaryKey(t => t.Sku);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        EventSku = c.String(nullable: false, maxLength: 17),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EventSku, t.Name })
                .ForeignKey("dbo.Events", t => t.EventSku, cascadeDelete: true)
                .Index(t => t.EventSku);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 5),
                        Name = c.String(),
                        RobotName = c.String(),
                        Organization = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        Country = c.String(),
                        IsRegistered = c.Boolean(nullable: false),
                        Level = c.Int(nullable: false),
                        Program = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Number);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        EventSku = c.String(nullable: false, maxLength: 17),
                        DivisionName = c.String(nullable: false, maxLength: 128),
                        Round = c.Int(nullable: false),
                        Instance = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Scheduled = c.DateTime(nullable: false),
                        Field = c.String(),
                        RedScore = c.Int(nullable: false),
                        BlueScore = c.Int(nullable: false),
                        RedScoreDetails = c.String(),
                        BlueScoreDetails = c.String(),
                        OfficialScored = c.Boolean(nullable: false),
                        Red1Number = c.String(maxLength: 5),
                        Red2Number = c.String(maxLength: 5),
                        Red3Number = c.String(maxLength: 5),
                        RedSitNumber = c.String(maxLength: 5),
                        Blue1Number = c.String(maxLength: 5),
                        Blue2Number = c.String(maxLength: 5),
                        Blue3Number = c.String(maxLength: 5),
                        BlueSitNumber = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => new { t.EventSku, t.DivisionName, t.Round, t.Instance, t.Number })
                .ForeignKey("dbo.Teams", t => t.Blue1Number)
                .ForeignKey("dbo.Teams", t => t.Blue2Number)
                .ForeignKey("dbo.Teams", t => t.Blue3Number)
                .ForeignKey("dbo.Teams", t => t.BlueSitNumber)
                .ForeignKey("dbo.Divisions", t => new { t.EventSku, t.DivisionName }, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Red1Number)
                .ForeignKey("dbo.Teams", t => t.Red2Number)
                .ForeignKey("dbo.Teams", t => t.Red3Number)
                .ForeignKey("dbo.Teams", t => t.RedSitNumber)
                .Index(t => new { t.EventSku, t.DivisionName })
                .Index(t => t.Red1Number)
                .Index(t => t.Red2Number)
                .Index(t => t.Red3Number)
                .Index(t => t.RedSitNumber)
                .Index(t => t.Blue1Number)
                .Index(t => t.Blue2Number)
                .Index(t => t.Blue3Number)
                .Index(t => t.BlueSitNumber);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        EventSku = c.String(nullable: false, maxLength: 17),
                        TeamNumber = c.String(nullable: false, maxLength: 5),
                        Type = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        ScoreDetails = c.String(),
                        Rank = c.Int(nullable: false),
                        Attempts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventSku, t.TeamNumber, t.Type })
                .ForeignKey("dbo.Events", t => t.EventSku, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamNumber, cascadeDelete: true)
                .Index(t => t.EventSku)
                .Index(t => t.TeamNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "TeamNumber", "dbo.Teams");
            DropForeignKey("dbo.Skills", "EventSku", "dbo.Events");
            DropForeignKey("dbo.Matches", "RedSitNumber", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red3Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red2Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red1Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", new[] { "EventSku", "DivisionName" }, "dbo.Divisions");
            DropForeignKey("dbo.Matches", "BlueSitNumber", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue3Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue2Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue1Number", "dbo.Teams");
            DropForeignKey("dbo.Awards", "TeamNumber", "dbo.Teams");
            DropForeignKey("dbo.Awards", "QualifiesFor_Sku", "dbo.Events");
            DropForeignKey("dbo.Awards", "EventSku", "dbo.Events");
            DropForeignKey("dbo.Divisions", "EventSku", "dbo.Events");
            DropIndex("dbo.Skills", new[] { "TeamNumber" });
            DropIndex("dbo.Skills", new[] { "EventSku" });
            DropIndex("dbo.Matches", new[] { "BlueSitNumber" });
            DropIndex("dbo.Matches", new[] { "Blue3Number" });
            DropIndex("dbo.Matches", new[] { "Blue2Number" });
            DropIndex("dbo.Matches", new[] { "Blue1Number" });
            DropIndex("dbo.Matches", new[] { "RedSitNumber" });
            DropIndex("dbo.Matches", new[] { "Red3Number" });
            DropIndex("dbo.Matches", new[] { "Red2Number" });
            DropIndex("dbo.Matches", new[] { "Red1Number" });
            DropIndex("dbo.Matches", new[] { "EventSku", "DivisionName" });
            DropIndex("dbo.Divisions", new[] { "EventSku" });
            DropIndex("dbo.Awards", new[] { "QualifiesFor_Sku" });
            DropIndex("dbo.Awards", new[] { "TeamNumber" });
            DropIndex("dbo.Awards", new[] { "EventSku" });
            DropTable("dbo.Skills");
            DropTable("dbo.Matches");
            DropTable("dbo.Teams");
            DropTable("dbo.Divisions");
            DropTable("dbo.Events");
            DropTable("dbo.Awards");
        }
    }
}
