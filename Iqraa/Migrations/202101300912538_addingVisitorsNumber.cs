namespace Iqraa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingVisitorsNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitorsNumbers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VisitorNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitorsNumbers");
        }
    }
}
