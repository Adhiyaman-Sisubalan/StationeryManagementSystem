namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdhiChanges2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "UnitOfMeasure", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "UnitOfMeasure", c => c.String(nullable: false));
        }
    }
}
