namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DisbursementLists", "Status", c => c.String());
            AddColumn("dbo.RetrievalLists", "RequestedQty", c => c.Int(nullable: false));
            DropColumn("dbo.RetrievalLists", "DisburseQty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RetrievalLists", "DisburseQty", c => c.Int(nullable: false));
            DropColumn("dbo.RetrievalLists", "RequestedQty");
            DropColumn("dbo.DisbursementLists", "Status");
        }
    }
}
