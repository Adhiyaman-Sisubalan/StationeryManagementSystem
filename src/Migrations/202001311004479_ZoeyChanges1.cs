namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZoeyChanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers_Price", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Suppliers_Price", new[] { "Supplier_SupplierId" });
            RenameColumn(table: "dbo.Suppliers_Price", name: "Supplier_SupplierId", newName: "SupplierId");
            AddColumn("dbo.Suppliers_Price", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Suppliers_Price", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Suppliers_Price", "SupplierId");
            AddForeignKey("dbo.Suppliers_Price", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers_Price", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Suppliers_Price", new[] { "SupplierId" });
            AlterColumn("dbo.Suppliers_Price", "SupplierId", c => c.Int());
            DropColumn("dbo.Suppliers_Price", "id");
            RenameColumn(table: "dbo.Suppliers_Price", name: "SupplierId", newName: "Supplier_SupplierId");
            CreateIndex("dbo.Suppliers_Price", "Supplier_SupplierId");
            AddForeignKey("dbo.Suppliers_Price", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
        }
    }
}
