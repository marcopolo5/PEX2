namespace Rooms.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormBGUP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.formular", "StareFormular", c => c.Int(nullable: false));
            DropColumn("dbo.formular", "formular_status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.formular", "formular_status", c => c.Int(nullable: false));
            DropColumn("dbo.formular", "StareFormular");
        }
    }
}
