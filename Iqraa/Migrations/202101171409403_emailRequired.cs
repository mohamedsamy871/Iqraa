namespace Iqraa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactUs", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactUs", "Email", c => c.String());
        }
    }
}
