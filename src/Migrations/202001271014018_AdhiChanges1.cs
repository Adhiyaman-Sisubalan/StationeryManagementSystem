namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdhiChanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdjustedItems", "ItemId", "dbo.Items");
            DropIndex("dbo.AdjustedItems", new[] { "ItemId" });
            RenameColumn(table: "dbo.AdjustedItems", name: "ItemId", newName: "Item_Id");
            AlterColumn("dbo.AdjustedItems", "Item_Id", c => c.Int());
            CreateIndex("dbo.AdjustedItems", "Item_Id");
            AddForeignKey("dbo.AdjustedItems", "Item_Id", "dbo.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdjustedItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.AdjustedItems", new[] { "Item_Id" });
            AlterColumn("dbo.AdjustedItems", "Item_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AdjustedItems", name: "Item_Id", newName: "ItemId");
            CreateIndex("dbo.AdjustedItems", "ItemId");
            AddForeignKey("dbo.AdjustedItems", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
