namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZoeyChanges2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdjustedItems", "SupplierPriceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdjustedItems", "SupplierPriceId");
        }
    }
}
