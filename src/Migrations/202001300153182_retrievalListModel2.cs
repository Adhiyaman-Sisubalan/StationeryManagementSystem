namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrievalListModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RetrievalLists", "StockQty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RetrievalLists", "StockQty");
        }
    }
}
