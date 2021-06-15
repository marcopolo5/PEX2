namespace Rooms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwoOneFk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.utilizator", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.utilizator", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.utilizator", "Address", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.utilizator", "Address");
            DropColumn("dbo.utilizator", "LastName");
            DropColumn("dbo.utilizator", "FirstName");
        }
    }
}
