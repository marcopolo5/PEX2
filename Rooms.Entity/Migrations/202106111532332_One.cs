namespace Rooms.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class One : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50),
                        parola = c.String(nullable: false, maxLength: 50),
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
                .ForeignKey("dbo.camin", t => t.caminID, cascadeDelete: true)
                .Index(t => t.caminID);
            
            CreateTable(
                "dbo.camin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nume = c.String(nullable: false, maxLength: 50),
                        adresa = c.String(nullable: false, maxLength: 50),
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
                //.ForeignKey("dbo.camera", t => t.cameraID, cascadeDelete: true)
               // .ForeignKey("dbo.camin", t => t.caminID, cascadeDelete: true)
               // .ForeignKey("dbo.student", t => t.studentID, cascadeDelete: true)
                .Index(t => t.studentID)
                .Index(t => t.caminID)
                .Index(t => t.cameraID);
            
            CreateTable(
                "dbo.student",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nume = c.String(nullable: false, maxLength: 50),
                        prenume = c.String(nullable: false, maxLength: 50),
                        medie = c.Double(nullable: false),
                        nr_telefon = c.String(nullable: false, unicode: false, storeType: "text"),
                        facultate = c.String(nullable: false, maxLength: 50),
                        raspuns = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.utilizator",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, unicode: false, storeType: "text"),
                        firstname = c.String(nullable: false, maxLength: 50),
                        lastname = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.formular", "studentID", "dbo.student");
            DropForeignKey("dbo.formular", "caminID", "dbo.camin");
            DropForeignKey("dbo.formular", "cameraID", "dbo.camera");
            DropForeignKey("dbo.camera", "caminID", "dbo.camin");
            DropIndex("dbo.formular", new[] { "cameraID" });
            DropIndex("dbo.formular", new[] { "caminID" });
            DropIndex("dbo.formular", new[] { "studentID" });
            DropIndex("dbo.camera", new[] { "caminID" });
            DropTable("dbo.utilizator");
            DropTable("dbo.student");
            DropTable("dbo.formular");
            DropTable("dbo.camin");
            DropTable("dbo.camera");
            DropTable("dbo.admin");
        }
    }
}
