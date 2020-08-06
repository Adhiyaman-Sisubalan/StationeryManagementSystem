namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif_changes2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DisbursementLists", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.DisbursementLists", new[] { "Department_DeptId" });
            RenameColumn(table: "dbo.DisbursementLists", name: "Department_DeptId", newName: "DeptId");
            AlterColumn("dbo.DisbursementLists", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.DisbursementLists", "DeptId");
            AddForeignKey("dbo.DisbursementLists", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisbursementLists", "DeptId", "dbo.Departments");
            DropIndex("dbo.DisbursementLists", new[] { "DeptId" });
            AlterColumn("dbo.DisbursementLists", "DeptId", c => c.Int());
            RenameColumn(table: "dbo.DisbursementLists", name: "DeptId", newName: "Department_DeptId");
            CreateIndex("dbo.DisbursementLists", "Department_DeptId");
            AddForeignKey("dbo.DisbursementLists", "Department_DeptId", "dbo.Departments", "DeptId");
        }
    }
}
