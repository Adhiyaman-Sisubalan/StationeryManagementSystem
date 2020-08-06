namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierId : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Suppliers_PriceItem", newName: "ItemSuppliers_Price");
            DropPrimaryKey("dbo.ItemSuppliers_Price");
            AddColumn("dbo.Items", "SupplierPriceId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ItemSuppliers_Price", new[] { "Item_Id", "Suppliers_Price_SuppliersPriceId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ItemSuppliers_Price");
            DropColumn("dbo.Items", "SupplierPriceId");
            AddPrimaryKey("dbo.ItemSuppliers_Price", new[] { "Suppliers_Price_SuppliersPriceId", "Item_Id" });
            RenameTable(name: "dbo.ItemSuppliers_Price", newName: "Suppliers_PriceItem");
        }
    }
}
