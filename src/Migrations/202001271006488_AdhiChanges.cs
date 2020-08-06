namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdhiChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdjustedItems", "AdjustmentReason", c => c.String());
            DropColumn("dbo.AdjustmentVouchers", "AdjustmentReason");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdjustmentVouchers", "AdjustmentReason", c => c.String());
            DropColumn("dbo.AdjustedItems", "AdjustmentReason");
        }
    }
}
