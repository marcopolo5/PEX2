namespace Rooms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullabe_username : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.utilizator", "username", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.utilizator", "username", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
