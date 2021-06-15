namespace Rooms.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test_rol_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.utilizator", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.utilizator", "Role");
        }
    }
}
