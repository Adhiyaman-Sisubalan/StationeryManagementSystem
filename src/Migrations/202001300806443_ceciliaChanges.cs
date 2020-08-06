namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ceciliaChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdjustedItems", "status", c => c.String());
            AddColumn("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", c => c.Int());
            CreateIndex("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId");
            AddForeignKey("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", "dbo.Suppliers_Price", "SuppliersPriceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId", "dbo.Suppliers_Price");
            DropIndex("dbo.AdjustedItems", new[] { "Suppliers_Prices_SuppliersPriceId" });
            DropColumn("dbo.AdjustedItems", "Suppliers_Prices_SuppliersPriceId");
            DropColumn("dbo.AdjustedItems", "status");
        }
    }
}
