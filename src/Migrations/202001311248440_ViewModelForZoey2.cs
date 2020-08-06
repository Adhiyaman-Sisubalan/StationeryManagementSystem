namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModelForZoey2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers_Price", "Itemid", c => c.Int(nullable: false));
            DropColumn("dbo.Suppliers_Price", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers_Price", "id", c => c.Int(nullable: false));
            DropColumn("dbo.Suppliers_Price", "Itemid");
        }
    }
}
