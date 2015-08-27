namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTeamMaxLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" }, "dbo.Awards");
            DropForeignKey("dbo.Awards", "TeamNumber", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue1Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue2Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue3Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "BlueSitNumber", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red1Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red2Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red3Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "RedSitNumber", "dbo.Teams");
            DropForeignKey("dbo.Skills", "TeamNumber", "dbo.Teams");
            DropIndex("dbo.Awards", new[] { "TeamNumber" });
            DropIndex("dbo.Matches", new[] { "Red1Number" });
            DropIndex("dbo.Matches", new[] { "Red2Number" });
            DropIndex("dbo.Matches", new[] { "Red3Number" });
            DropIndex("dbo.Matches", new[] { "RedSitNumber" });
            DropIndex("dbo.Matches", new[] { "Blue1Number" });
            DropIndex("dbo.Matches", new[] { "Blue2Number" });
            DropIndex("dbo.Matches", new[] { "Blue3Number" });
            DropIndex("dbo.Matches", new[] { "BlueSitNumber" });
            DropIndex("dbo.Skills", new[] { "TeamNumber" });
            DropIndex("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" });
            DropPrimaryKey("dbo.Awards");
            DropPrimaryKey("dbo.Teams");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.AwardEvents");
            AlterColumn("dbo.Awards", "TeamNumber", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Teams", "Number", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Matches", "Red1Number", c => c.String(maxLength: 6));
            AlterColumn("dbo.Matches", "Red2Number", c => c.String(maxLength: 6));
            AlterColumn("dbo.Matches", "Red3Number", c => c.String(maxLength: 6));
            AlterColumn("dbo.Matches", "RedSitNumber", c => c.String(maxLength: 6));
            AlterColumn("dbo.Matches", "Blue1Number", c => c.String(maxLength: 6));
            AlterColumn("dbo.Matches", "Blue2Number", c => c.String(maxLength: 6));
            AlterColumn("dbo.Matches", "Blue3Number", c => c.String(maxLength: 6));
            AlterColumn("dbo.Matches", "BlueSitNumber", c => c.String(maxLength: 6));
            AlterColumn("dbo.Skills", "TeamNumber", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.AwardEvents", "Award_TeamNumber", c => c.String(nullable: false, maxLength: 6));
            AddPrimaryKey("dbo.Awards", new[] { "EventSku", "Name", "TeamNumber" });
            AddPrimaryKey("dbo.Teams", "Number");
            AddPrimaryKey("dbo.Skills", new[] { "EventSku", "TeamNumber", "Type" });
            AddPrimaryKey("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber", "Event_Sku" });
            CreateIndex("dbo.Awards", "TeamNumber");
            CreateIndex("dbo.Matches", "Red1Number");
            CreateIndex("dbo.Matches", "Red2Number");
            CreateIndex("dbo.Matches", "Red3Number");
            CreateIndex("dbo.Matches", "RedSitNumber");
            CreateIndex("dbo.Matches", "Blue1Number");
            CreateIndex("dbo.Matches", "Blue2Number");
            CreateIndex("dbo.Matches", "Blue3Number");
            CreateIndex("dbo.Matches", "BlueSitNumber");
            CreateIndex("dbo.Skills", "TeamNumber");
            CreateIndex("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" });
            AddForeignKey("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" }, "dbo.Awards", new[] { "EventSku", "Name", "TeamNumber" }, cascadeDelete: true);
            AddForeignKey("dbo.Awards", "TeamNumber", "dbo.Teams", "Number", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "Blue1Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Blue2Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Blue3Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "BlueSitNumber", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Red1Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Red2Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Red3Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "RedSitNumber", "dbo.Teams", "Number");
            AddForeignKey("dbo.Skills", "TeamNumber", "dbo.Teams", "Number", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "TeamNumber", "dbo.Teams");
            DropForeignKey("dbo.Matches", "RedSitNumber", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red3Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red2Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Red1Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "BlueSitNumber", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue3Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue2Number", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Blue1Number", "dbo.Teams");
            DropForeignKey("dbo.Awards", "TeamNumber", "dbo.Teams");
            DropForeignKey("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" }, "dbo.Awards");
            DropIndex("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" });
            DropIndex("dbo.Skills", new[] { "TeamNumber" });
            DropIndex("dbo.Matches", new[] { "BlueSitNumber" });
            DropIndex("dbo.Matches", new[] { "Blue3Number" });
            DropIndex("dbo.Matches", new[] { "Blue2Number" });
            DropIndex("dbo.Matches", new[] { "Blue1Number" });
            DropIndex("dbo.Matches", new[] { "RedSitNumber" });
            DropIndex("dbo.Matches", new[] { "Red3Number" });
            DropIndex("dbo.Matches", new[] { "Red2Number" });
            DropIndex("dbo.Matches", new[] { "Red1Number" });
            DropIndex("dbo.Awards", new[] { "TeamNumber" });
            DropPrimaryKey("dbo.AwardEvents");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.Teams");
            DropPrimaryKey("dbo.Awards");
            AlterColumn("dbo.AwardEvents", "Award_TeamNumber", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Skills", "TeamNumber", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Matches", "BlueSitNumber", c => c.String(maxLength: 5));
            AlterColumn("dbo.Matches", "Blue3Number", c => c.String(maxLength: 5));
            AlterColumn("dbo.Matches", "Blue2Number", c => c.String(maxLength: 5));
            AlterColumn("dbo.Matches", "Blue1Number", c => c.String(maxLength: 5));
            AlterColumn("dbo.Matches", "RedSitNumber", c => c.String(maxLength: 5));
            AlterColumn("dbo.Matches", "Red3Number", c => c.String(maxLength: 5));
            AlterColumn("dbo.Matches", "Red2Number", c => c.String(maxLength: 5));
            AlterColumn("dbo.Matches", "Red1Number", c => c.String(maxLength: 5));
            AlterColumn("dbo.Teams", "Number", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Awards", "TeamNumber", c => c.String(nullable: false, maxLength: 5));
            AddPrimaryKey("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber", "Event_Sku" });
            AddPrimaryKey("dbo.Skills", new[] { "EventSku", "TeamNumber", "Type" });
            AddPrimaryKey("dbo.Teams", "Number");
            AddPrimaryKey("dbo.Awards", new[] { "EventSku", "Name", "TeamNumber" });
            CreateIndex("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" });
            CreateIndex("dbo.Skills", "TeamNumber");
            CreateIndex("dbo.Matches", "BlueSitNumber");
            CreateIndex("dbo.Matches", "Blue3Number");
            CreateIndex("dbo.Matches", "Blue2Number");
            CreateIndex("dbo.Matches", "Blue1Number");
            CreateIndex("dbo.Matches", "RedSitNumber");
            CreateIndex("dbo.Matches", "Red3Number");
            CreateIndex("dbo.Matches", "Red2Number");
            CreateIndex("dbo.Matches", "Red1Number");
            CreateIndex("dbo.Awards", "TeamNumber");
            AddForeignKey("dbo.Skills", "TeamNumber", "dbo.Teams", "Number", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "RedSitNumber", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Red3Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Red2Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Red1Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "BlueSitNumber", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Blue3Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Blue2Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Matches", "Blue1Number", "dbo.Teams", "Number");
            AddForeignKey("dbo.Awards", "TeamNumber", "dbo.Teams", "Number", cascadeDelete: true);
            AddForeignKey("dbo.AwardEvents", new[] { "Award_EventSku", "Award_Name", "Award_TeamNumber" }, "dbo.Awards", new[] { "EventSku", "Name", "TeamNumber" }, cascadeDelete: true);
        }
    }
}
