namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockdetailsmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockDetails", "Item_Id", "dbo.Items");
            DropIndex("dbo.StockDetails", new[] { "Item_Id" });
            RenameColumn(table: "dbo.StockDetails", name: "Item_Id", newName: "ItemId");
            AlterColumn("dbo.StockDetails", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.StockDetails", "ItemId");
            AddForeignKey("dbo.StockDetails", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockDetails", "ItemId", "dbo.Items");
            DropIndex("dbo.StockDetails", new[] { "ItemId" });
            AlterColumn("dbo.StockDetails", "ItemId", c => c.Int());
            RenameColumn(table: "dbo.StockDetails", name: "ItemId", newName: "Item_Id");
            CreateIndex("dbo.StockDetails", "Item_Id");
            AddForeignKey("dbo.StockDetails", "Item_Id", "dbo.Items", "Id");
        }
    }
}
