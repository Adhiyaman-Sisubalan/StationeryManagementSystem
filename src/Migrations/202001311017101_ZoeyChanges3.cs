namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZoeyChanges3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", "dbo.Suppliers_Price");
            DropIndex("dbo.AdjustedItems", new[] { "Suppliers_Prices_SuppliersPriceId" });
            DropColumn("dbo.AdjustedItems", "SupplierPriceId");
            RenameColumn(table: "dbo.AdjustedItems", name: "Suppliers_Prices_SuppliersPriceId", newName: "SupplierPriceId");
            AlterColumn("dbo.AdjustedItems", "SupplierPriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdjustedItems", "SupplierPriceId");
            AddForeignKey("dbo.AdjustedItems", "SupplierPriceId", "dbo.Suppliers_Price", "SuppliersPriceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdjustedItems", "SupplierPriceId", "dbo.Suppliers_Price");
            DropIndex("dbo.AdjustedItems", new[] { "SupplierPriceId" });
            AlterColumn("dbo.AdjustedItems", "SupplierPriceId", c => c.Int());
            RenameColumn(table: "dbo.AdjustedItems", name: "SupplierPriceId", newName: "Suppliers_Prices_SuppliersPriceId");
            AddColumn("dbo.AdjustedItems", "SupplierPriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId");
            AddForeignKey("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", "dbo.Suppliers_Price", "SuppliersPriceId");
        }
    }
}
