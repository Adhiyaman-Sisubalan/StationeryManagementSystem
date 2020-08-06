namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datemodelchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConsolidatedRequisitions", "RequestedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConsolidatedRequisitions", "RequestedDate");
        }
    }
}
