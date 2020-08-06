namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datemodelchanges1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConsolidatedRequisitions", "RequestedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConsolidatedRequisitions", "RequestedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
