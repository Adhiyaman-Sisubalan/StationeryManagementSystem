namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZoeyChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers_Price", "Item_Id", "dbo.Items");
            DropIndex("dbo.Suppliers_Price", new[] { "Item_Id" });
            CreateTable(
                "dbo.Suppliers_PriceItem",
                c => new
                    {
                        Suppliers_Price_SuppliersPriceId = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Suppliers_Price_SuppliersPriceId, t.Item_Id })
                .ForeignKey("dbo.Suppliers_Price", t => t.Suppliers_Price_SuppliersPriceId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Suppliers_Price_SuppliersPriceId)
                .Index(t => t.Item_Id);
            
            DropColumn("dbo.Suppliers_Price", "Item_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers_Price", "Item_Id", c => c.Int());
            DropForeignKey("dbo.Suppliers_PriceItem", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Suppliers_PriceItem", "Suppliers_Price_SuppliersPriceId", "dbo.Suppliers_Price");
            DropIndex("dbo.Suppliers_PriceItem", new[] { "Item_Id" });
            DropIndex("dbo.Suppliers_PriceItem", new[] { "Suppliers_Price_SuppliersPriceId" });
            DropTable("dbo.Suppliers_PriceItem");
            CreateIndex("dbo.Suppliers_Price", "Item_Id");
            AddForeignKey("dbo.Suppliers_Price", "Item_Id", "dbo.Items", "Id");
        }
    }
}
