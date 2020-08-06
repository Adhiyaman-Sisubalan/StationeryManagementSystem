namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrievalListModel6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeptRequestedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        itemId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        DeptRequestedQtyForEachItem = c.Int(nullable: false),
                        ActualDeliveredQtyForEachItem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.itemId, cascadeDelete: true)
                .Index(t => t.itemId)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeptRequestedItems", "itemId", "dbo.Items");
            DropForeignKey("dbo.DeptRequestedItems", "DeptId", "dbo.Departments");
            DropIndex("dbo.DeptRequestedItems", new[] { "DeptId" });
            DropIndex("dbo.DeptRequestedItems", new[] { "itemId" });
            DropTable("dbo.DeptRequestedItems");
        }
    }
}
