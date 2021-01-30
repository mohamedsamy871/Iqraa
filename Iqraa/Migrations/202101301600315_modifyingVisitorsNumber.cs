namespace Iqraa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyingVisitorsNumber : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VisitorsNumbers");
            AlterColumn("dbo.VisitorsNumbers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.VisitorsNumbers", "VisitorNumber", c => c.Int());
            AddPrimaryKey("dbo.VisitorsNumbers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VisitorsNumbers");
            AlterColumn("dbo.VisitorsNumbers", "VisitorNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.VisitorsNumbers", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.VisitorsNumbers", "Id");
        }
    }
}
