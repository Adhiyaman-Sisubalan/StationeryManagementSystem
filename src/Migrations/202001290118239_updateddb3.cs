namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddb3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectionOfRequestedItems", "ConsolidatedRequisition_ConsolidatedRequisitionId", "dbo.ConsolidatedRequisitions");
            DropIndex("dbo.CollectionOfRequestedItems", new[] { "ConsolidatedRequisition_ConsolidatedRequisitionId" });
            RenameColumn(table: "dbo.CollectionOfRequestedItems", name: "ConsolidatedRequisition_ConsolidatedRequisitionId", newName: "ConsolidatedRequisitionId");
            AlterColumn("dbo.CollectionOfRequestedItems", "ConsolidatedRequisitionId", c => c.Int(nullable: false));
            CreateIndex("dbo.CollectionOfRequestedItems", "ConsolidatedRequisitionId");
            AddForeignKey("dbo.CollectionOfRequestedItems", "ConsolidatedRequisitionId", "dbo.ConsolidatedRequisitions", "ConsolidatedRequisitionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionOfRequestedItems", "ConsolidatedRequisitionId", "dbo.ConsolidatedRequisitions");
            DropIndex("dbo.CollectionOfRequestedItems", new[] { "ConsolidatedRequisitionId" });
            AlterColumn("dbo.CollectionOfRequestedItems", "ConsolidatedRequisitionId", c => c.Int());
            RenameColumn(table: "dbo.CollectionOfRequestedItems", name: "ConsolidatedRequisitionId", newName: "ConsolidatedRequisition_ConsolidatedRequisitionId");
            CreateIndex("dbo.CollectionOfRequestedItems", "ConsolidatedRequisition_ConsolidatedRequisitionId");
            AddForeignKey("dbo.CollectionOfRequestedItems", "ConsolidatedRequisition_ConsolidatedRequisitionId", "dbo.ConsolidatedRequisitions", "ConsolidatedRequisitionId");
        }
    }
}
