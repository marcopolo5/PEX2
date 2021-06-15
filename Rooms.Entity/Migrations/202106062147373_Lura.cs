namespace Rooms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.utilizator", "tip_id", "dbo.tip");
            DropIndex("dbo.utilizator", new[] { "tip_id" });
            AddColumn("dbo.utilizator", "password", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.utilizator", "parola");
            DropColumn("dbo.utilizator", "tipID");
            DropColumn("dbo.utilizator", "Address");
            DropColumn("dbo.utilizator", "tip_id");
            DropTable("dbo.tip");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tip",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rol = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.utilizator", "tip_id", c => c.Int(nullable: false));
            AddColumn("dbo.utilizator", "Address", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.utilizator", "tipID", c => c.String());
            AddColumn("dbo.utilizator", "parola", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.utilizator", "password");
            CreateIndex("dbo.utilizator", "tip_id");
            AddForeignKey("dbo.utilizator", "tip_id", "dbo.tip", "id");
        }
    }
}
