namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrievalListModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RetrievalLists", "Stock_StockDetailsId", c => c.Int());
            CreateIndex("dbo.RetrievalLists", "Stock_StockDetailsId");
            AddForeignKey("dbo.RetrievalLists", "Stock_StockDetailsId", "dbo.StockDetails", "StockDetailsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RetrievalLists", "Stock_StockDetailsId", "dbo.StockDetails");
            DropIndex("dbo.RetrievalLists", new[] { "Stock_StockDetailsId" });
            DropColumn("dbo.RetrievalLists", "Stock_StockDetailsId");
        }
    }
}
