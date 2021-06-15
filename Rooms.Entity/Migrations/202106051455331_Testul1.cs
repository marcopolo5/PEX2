namespace Rooms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testul1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        parola = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.camera",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nr_camera = c.Int(nullable: false),
                        nr_paturi = c.Int(nullable: false),
                        caminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.camin", t => t.caminID)
                .Index(t => t.caminID);
            
            CreateTable(
                "dbo.camin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nume = c.String(nullable: false, maxLength: 50, unicode: false),
                        adresa = c.String(nullable: false, maxLength: 50, unicode: false),
                        nr_camere = c.Int(nullable: false),
                        nr_etaje = c.Int(nullable: false),
                        nr_paturi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.formular",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        studentID = c.Int(nullable: false),
                        caminID = c.Int(nullable: false),
                        cameraID = c.Int(nullable: false),
                        nr_pat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.student", t => t.studentID)
                .ForeignKey("dbo.camin", t => t.caminID)
                .ForeignKey("dbo.camera", t => t.cameraID)
                .Index(t => t.studentID)
                .Index(t => t.caminID)
                .Index(t => t.cameraID);
            
            CreateTable(
                "dbo.student",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nume = c.String(nullable: false, maxLength: 50, unicode: false),
                        prenume = c.String(nullable: false, maxLength: 50, unicode: false),
                        medie = c.Double(nullable: false),
                        nr_telefon = c.String(nullable: false, unicode: false, storeType: "text"),
                        facultate = c.String(nullable: false, maxLength: 50, unicode: false),
                        raspuns = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tip",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rol = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.utilizator",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        parola = c.String(nullable: false, maxLength: 50, unicode: false),
                        email = c.String(nullable: false, unicode: false, storeType: "text"),
                        tipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tip", t => t.tipID)
                .Index(t => t.tipID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.utilizator", "tipID", "dbo.tip");
            DropForeignKey("dbo.formular", "cameraID", "dbo.camera");
            DropForeignKey("dbo.formular", "caminID", "dbo.camin");
            DropForeignKey("dbo.formular", "studentID", "dbo.student");
            DropForeignKey("dbo.camera", "caminID", "dbo.camin");
            DropIndex("dbo.utilizator", new[] { "tipID" });
            DropIndex("dbo.formular", new[] { "cameraID" });
            DropIndex("dbo.formular", new[] { "caminID" });
            DropIndex("dbo.formular", new[] { "studentID" });
            DropIndex("dbo.camera", new[] { "caminID" });
            DropTable("dbo.utilizator");
            DropTable("dbo.tip");
            DropTable("dbo.student");
            DropTable("dbo.formular");
            DropTable("dbo.camin");
            DropTable("dbo.camera");
            DropTable("dbo.admin");
        }
    }
}
