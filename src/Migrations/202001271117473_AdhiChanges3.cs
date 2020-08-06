namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdhiChanges3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdjustedItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.AdjustedItems", new[] { "Item_Id" });
            RenameColumn(table: "dbo.AdjustedItems", name: "Item_Id", newName: "ItemId");
            AlterColumn("dbo.AdjustedItems", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdjustedItems", "ItemId");
            AddForeignKey("dbo.AdjustedItems", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdjustedItems", "ItemId", "dbo.Items");
            DropIndex("dbo.AdjustedItems", new[] { "ItemId" });
            AlterColumn("dbo.AdjustedItems", "ItemId", c => c.Int());
            RenameColumn(table: "dbo.AdjustedItems", name: "ItemId", newName: "Item_Id");
            CreateIndex("dbo.AdjustedItems", "Item_Id");
            AddForeignKey("dbo.AdjustedItems", "Item_Id", "dbo.Items", "Id");
        }
    }
}
