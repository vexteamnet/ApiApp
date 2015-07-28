namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAwardReferences : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Awards", "QualifiesFor_Sku", "dbo.Events");
            DropForeignKey("dbo.Awards", "EventSku", "dbo.Events");
            DropIndex("dbo.Awards", new[] { "QualifiesFor_Sku" });
            CreateTable(
                "dbo.AwardEvents",
                c => new
                    {
                        Award_EventSku = c.String(nullable: false, maxLength: 17),
                        Award_Name = c.String(nullable: false, maxLength: 128),
                        Award_TeamNumber = c.String(nullable: false, maxLength: 5),
                        Event_Sku = c.String(nullable: false, maxLength: 17),
                    })
                .PrimaryKey(t => new { t.Award_EventSku, t.Award_Name, t.Award_TeamNumber, t.Event_Sku })
                .ForeignKey("dbo.Awards", t => new { t.Award_EventSku, t.Award_Name, t.Award_TeamNumber }, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Sku, cascadeDelete: true)
                .Index(t => new { t.Award_EventSku, t.Award_Name, t.Award_TeamNumber })
                .Index(t => t.Event_Sku);
            
            AddForeignKey("dbo.Awards", "EventSku", "dbo.Events", "Sku");
            DropColumn("dbo.Awards", "QualifiesFor_Sku");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Awards", "QualifiesFor_Sku", c => c.String(maxLength: 17));
            DropForeignKey("dbo.Awards", "EventSku", "dbo.Events");
            DropForeignKey("dbo.AwardEvents", "Event_Sku", "dbo.Events");
            DropForeignKey("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" }, "dbo.Awards");
            DropIndex("dbo.AwardEvents", new[] { "Event_Sku" });
            DropIndex("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" });
            DropTable("dbo.AwardEvents");
            CreateIndex("dbo.Awards", "QualifiesFor_Sku");
            AddForeignKey("dbo.Awards", "EventSku", "dbo.Events", "Sku", cascadeDelete: true);
            AddForeignKey("dbo.Awards", "QualifiesFor_Sku", "dbo.Events", "Sku");
        }
    }
}
