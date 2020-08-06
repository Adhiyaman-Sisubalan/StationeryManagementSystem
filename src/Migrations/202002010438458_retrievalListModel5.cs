namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrievalListModel5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RetrievalLists", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.RetrievalLists", "Item_Id", "dbo.Items");
            DropIndex("dbo.RetrievalLists", new[] { "Department_DeptId" });
            DropIndex("dbo.RetrievalLists", new[] { "Item_Id" });
            RenameColumn(table: "dbo.RetrievalLists", name: "Department_DeptId", newName: "DeptId");
            RenameColumn(table: "dbo.RetrievalLists", name: "Item_Id", newName: "ItemId");
            AddColumn("dbo.RetrievalLists", "RequestedQty", c => c.Int(nullable: false));
            AddColumn("dbo.RetrievalLists", "ActualQty", c => c.Int(nullable: false));
            AlterColumn("dbo.RetrievalLists", "DeptId", c => c.Int(nullable: false));
            AlterColumn("dbo.RetrievalLists", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.RetrievalLists", "DeptId");
            CreateIndex("dbo.RetrievalLists", "ItemId");
            AddForeignKey("dbo.RetrievalLists", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
            AddForeignKey("dbo.RetrievalLists", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
            DropColumn("dbo.RetrievalLists", "TotalRequestedQty");
            DropColumn("dbo.RetrievalLists", "StockQty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RetrievalLists", "StockQty", c => c.Int(nullable: false));
            AddColumn("dbo.RetrievalLists", "TotalRequestedQty", c => c.Int(nullable: false));
            DropForeignKey("dbo.RetrievalLists", "ItemId", "dbo.Items");
            DropForeignKey("dbo.RetrievalLists", "DeptId", "dbo.Departments");
            DropIndex("dbo.RetrievalLists", new[] { "ItemId" });
            DropIndex("dbo.RetrievalLists", new[] { "DeptId" });
            AlterColumn("dbo.RetrievalLists", "ItemId", c => c.Int());
            AlterColumn("dbo.RetrievalLists", "DeptId", c => c.Int());
            DropColumn("dbo.RetrievalLists", "ActualQty");
            DropColumn("dbo.RetrievalLists", "RequestedQty");
            RenameColumn(table: "dbo.RetrievalLists", name: "ItemId", newName: "Item_Id");
            RenameColumn(table: "dbo.RetrievalLists", name: "DeptId", newName: "Department_DeptId");
            CreateIndex("dbo.RetrievalLists", "Item_Id");
            CreateIndex("dbo.RetrievalLists", "Department_DeptId");
            AddForeignKey("dbo.RetrievalLists", "Item_Id", "dbo.Items", "Id");
            AddForeignKey("dbo.RetrievalLists", "Department_DeptId", "dbo.Departments", "DeptId");
        }
    }
}
