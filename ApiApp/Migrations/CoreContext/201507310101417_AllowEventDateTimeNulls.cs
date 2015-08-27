namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowEventDateTimeNulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime());
            AlterColumn("dbo.Events", "Finish", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Finish", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false));
        }
    }
}
