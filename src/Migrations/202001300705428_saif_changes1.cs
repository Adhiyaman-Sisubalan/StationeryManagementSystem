namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif_changes1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DisburseItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.DisburseItems", new[] { "Item_Id" });
            RenameColumn(table: "dbo.DisburseItems", name: "Item_Id", newName: "ItemId");
            AlterColumn("dbo.DisburseItems", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.DisburseItems", "ItemId");
            AddForeignKey("dbo.DisburseItems", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisburseItems", "ItemId", "dbo.Items");
            DropIndex("dbo.DisburseItems", new[] { "ItemId" });
            AlterColumn("dbo.DisburseItems", "ItemId", c => c.Int());
            RenameColumn(table: "dbo.DisburseItems", name: "ItemId", newName: "Item_Id");
            CreateIndex("dbo.DisburseItems", "Item_Id");
            AddForeignKey("dbo.DisburseItems", "Item_Id", "dbo.Items", "Id");
        }
    }
}
