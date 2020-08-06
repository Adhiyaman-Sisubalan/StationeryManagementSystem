namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierId1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemSuppliers_Price", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemSuppliers_Price", "Suppliers_Price_SuppliersPriceId", "dbo.Suppliers_Price");
            DropIndex("dbo.ItemSuppliers_Price", new[] { "Item_Id" });
            DropIndex("dbo.ItemSuppliers_Price", new[] { "Suppliers_Price_SuppliersPriceId" });
            CreateIndex("dbo.Suppliers_Price", "Itemid");
         //   AddForeignKey("dbo.Suppliers_Price", "Itemid", "dbo.Items", "Id", cascadeDelete: true);
            DropTable("dbo.ItemSuppliers_Price");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemSuppliers_Price",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Suppliers_Price_SuppliersPriceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Suppliers_Price_SuppliersPriceId });
            
            DropForeignKey("dbo.Suppliers_Price", "Itemid", "dbo.Items");
            DropIndex("dbo.Suppliers_Price", new[] { "Itemid" });
            CreateIndex("dbo.ItemSuppliers_Price", "Suppliers_Price_SuppliersPriceId");
            CreateIndex("dbo.ItemSuppliers_Price", "Item_Id");
            AddForeignKey("dbo.ItemSuppliers_Price", "Suppliers_Price_SuppliersPriceId", "dbo.Suppliers_Price", "SuppliersPriceId", cascadeDelete: true);
            AddForeignKey("dbo.ItemSuppliers_Price", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
