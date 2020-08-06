namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKeyInEmployeeREquest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeRequestForms", "DeptStaff_UserId", "dbo.Dept_Staff");
            DropIndex("dbo.EmployeeRequestForms", new[] { "DeptStaff_UserId" });
            RenameColumn(table: "dbo.EmployeeRequestForms", name: "DeptStaff_UserId", newName: "DeptStaffId");
            AlterColumn("dbo.EmployeeRequestForms", "DeptStaffId", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeRequestForms", "DeptStaffId");
            AddForeignKey("dbo.EmployeeRequestForms", "DeptStaffId", "dbo.Dept_Staff", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeRequestForms", "DeptStaffId", "dbo.Dept_Staff");
            DropIndex("dbo.EmployeeRequestForms", new[] { "DeptStaffId" });
            AlterColumn("dbo.EmployeeRequestForms", "DeptStaffId", c => c.Int());
            RenameColumn(table: "dbo.EmployeeRequestForms", name: "DeptStaffId", newName: "DeptStaff_UserId");
            CreateIndex("dbo.EmployeeRequestForms", "DeptStaff_UserId");
            AddForeignKey("dbo.EmployeeRequestForms", "DeptStaff_UserId", "dbo.Dept_Staff", "UserId");
        }
    }
}
