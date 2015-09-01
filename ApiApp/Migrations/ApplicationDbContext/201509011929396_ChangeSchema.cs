namespace ApiApp.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.AspNetRoles", newSchema: "id");
            MoveTable(name: "dbo.AspNetUserRoles", newSchema: "id");
            MoveTable(name: "dbo.AspNetUsers", newSchema: "id");
            MoveTable(name: "dbo.AspNetUserClaims", newSchema: "id");
            MoveTable(name: "dbo.AspNetUserLogins", newSchema: "id");
        }
        
        public override void Down()
        {
            MoveTable(name: "id.AspNetUserLogins", newSchema: "dbo");
            MoveTable(name: "id.AspNetUserClaims", newSchema: "dbo");
            MoveTable(name: "id.AspNetUsers", newSchema: "dbo");
            MoveTable(name: "id.AspNetUserRoles", newSchema: "dbo");
            MoveTable(name: "id.AspNetRoles", newSchema: "dbo");
        }
    }
}
