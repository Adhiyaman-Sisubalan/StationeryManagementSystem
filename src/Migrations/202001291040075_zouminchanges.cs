namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zouminchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "StockDetailsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "StockDetailsId");
        }
    }
}
