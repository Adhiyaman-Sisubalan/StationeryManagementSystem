namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModelForZoey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdjustedItems", "SupplierPriceId", "dbo.Suppliers_Price");
            DropIndex("dbo.AdjustedItems", new[] { "SupplierPriceId" });
            RenameColumn(table: "dbo.AdjustedItems", name: "SupplierPriceId", newName: "Suppliers_Prices_SuppliersPriceId");
            AlterColumn("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", c => c.Int());
            CreateIndex("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId");
            AddForeignKey("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", "dbo.Suppliers_Price", "SuppliersPriceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", "dbo.Suppliers_Price");
            DropIndex("dbo.AdjustedItems", new[] { "Suppliers_Prices_SuppliersPriceId" });
            AlterColumn("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AdjustedItems", name: "Suppliers_Prices_SuppliersPriceId", newName: "SupplierPriceId");
            CreateIndex("dbo.AdjustedItems", "SupplierPriceId");
            AddForeignKey("dbo.AdjustedItems", "SupplierPriceId", "dbo.Suppliers_Price", "SuppliersPriceId", cascadeDelete: true);
        }
    }
}
