namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowMatchDateTimeNulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Matches", "Scheduled", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Matches", "Scheduled", c => c.DateTime(nullable: false));
        }
    }
}
