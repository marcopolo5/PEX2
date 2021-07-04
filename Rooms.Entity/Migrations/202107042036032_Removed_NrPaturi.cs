namespace Rooms.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_NrPaturi : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.formular", "nr_pat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.formular", "nr_pat", c => c.Int(nullable: false));
        }
    }
}
