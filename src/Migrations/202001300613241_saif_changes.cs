namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RetrievalLists", "TotalRequestedQty", c => c.Int(nullable: false));
            DropColumn("dbo.RetrievalLists", "RequestedQty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RetrievalLists", "RequestedQty", c => c.Int(nullable: false));
            DropColumn("dbo.RetrievalLists", "TotalRequestedQty");
        }
    }
}
