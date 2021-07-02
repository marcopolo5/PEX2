namespace Rooms.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Formular_Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.formular", "formular_status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.formular", "formular_status");
        }
    }
}
