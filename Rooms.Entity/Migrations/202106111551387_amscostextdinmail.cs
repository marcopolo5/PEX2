namespace Rooms.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amscostextdinmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.utilizator", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.utilizator", "email", c => c.String(nullable: false, unicode: false, storeType: "text"));
        }
    }
}
