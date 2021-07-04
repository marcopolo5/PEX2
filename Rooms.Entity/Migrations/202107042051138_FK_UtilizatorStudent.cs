namespace Rooms.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK_UtilizatorStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.utilizator", "Student_id", c => c.Int());
            CreateIndex("dbo.utilizator", "Student_id");
            AddForeignKey("dbo.utilizator", "Student_id", "dbo.student", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.utilizator", "Student_id", "dbo.student");
            DropIndex("dbo.utilizator", new[] { "Student_id" });
            DropColumn("dbo.utilizator", "Student_id");
        }
    }
}
