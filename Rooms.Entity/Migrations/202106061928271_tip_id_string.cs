namespace Rooms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tip_id_string : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.utilizator", "tipID", "dbo.tip");
            DropIndex("dbo.utilizator", new[] { "tipID" });
            AddColumn("dbo.utilizator", "tip_id", c => c.Int(nullable: false));
            AlterColumn("dbo.utilizator", "tipID", c => c.String());
            CreateIndex("dbo.utilizator", "tip_id");
            AddForeignKey("dbo.utilizator", "tip_id", "dbo.tip", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.utilizator", "tip_id", "dbo.tip");
            DropIndex("dbo.utilizator", new[] { "tip_id" });
            AlterColumn("dbo.utilizator", "tipID", c => c.Int(nullable: false));
            DropColumn("dbo.utilizator", "tip_id");
            CreateIndex("dbo.utilizator", "tipID");
            AddForeignKey("dbo.utilizator", "tipID", "dbo.tip", "id");
        }
    }
}
