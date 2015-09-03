namespace ApiApp.Migrations.CoreContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateToInternalModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "LastUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "LastUpdated");
        }
    }
}
