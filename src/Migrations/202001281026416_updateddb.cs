namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RetrievalLists",
                c => new
                    {
                        RetrievalListId = c.Int(nullable: false, identity: true),
                        DisburseQty = c.Int(nullable: false),
                        Department_DeptId = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RetrievalListId)
                .ForeignKey("dbo.Departments", t => t.Department_DeptId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Department_DeptId)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RetrievalLists", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.RetrievalLists", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.RetrievalLists", new[] { "Item_Id" });
            DropIndex("dbo.RetrievalLists", new[] { "Department_DeptId" });
            DropTable("dbo.RetrievalLists");
        }
    }
}
