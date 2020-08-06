namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddb2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsolidatedRequisitions", "deptId", "dbo.Departments");
            DropIndex("dbo.ConsolidatedRequisitions", new[] { "deptId" });
            AlterColumn("dbo.ConsolidatedRequisitions", "deptId", c => c.Int(nullable: false));
            CreateIndex("dbo.ConsolidatedRequisitions", "deptId");
            AddForeignKey("dbo.ConsolidatedRequisitions", "deptId", "dbo.Departments", "DeptId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsolidatedRequisitions", "deptId", "dbo.Departments");
            DropIndex("dbo.ConsolidatedRequisitions", new[] { "deptId" });
            AlterColumn("dbo.ConsolidatedRequisitions", "deptId", c => c.Int());
            CreateIndex("dbo.ConsolidatedRequisitions", "deptId");
            AddForeignKey("dbo.ConsolidatedRequisitions", "deptId", "dbo.Departments", "DeptId");
        }
    }
}
