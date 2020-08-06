namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeReqst : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestItems", "EmployeeRequestFormId", "dbo.EmployeeRequestForms");
            DropIndex("dbo.RequestItems", new[] { "EmployeeRequestFormId" });
            RenameColumn(table: "dbo.RequestItems", name: "EmployeeRequestFormId", newName: "EmployeeRequest_EmployeeRequestFormId");
            AlterColumn("dbo.RequestItems", "EmployeeRequest_EmployeeRequestFormId", c => c.Int());
            CreateIndex("dbo.RequestItems", "EmployeeRequest_EmployeeRequestFormId");
            AddForeignKey("dbo.RequestItems", "EmployeeRequest_EmployeeRequestFormId", "dbo.EmployeeRequestForms", "EmployeeRequestFormId");
            DropColumn("dbo.EmployeeRequestForms", "RequestSubmissionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeRequestForms", "RequestSubmissionDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.RequestItems", "EmployeeRequest_EmployeeRequestFormId", "dbo.EmployeeRequestForms");
            DropIndex("dbo.RequestItems", new[] { "EmployeeRequest_EmployeeRequestFormId" });
            AlterColumn("dbo.RequestItems", "EmployeeRequest_EmployeeRequestFormId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RequestItems", name: "EmployeeRequest_EmployeeRequestFormId", newName: "EmployeeRequestFormId");
            CreateIndex("dbo.RequestItems", "EmployeeRequestFormId");
            AddForeignKey("dbo.RequestItems", "EmployeeRequestFormId", "dbo.EmployeeRequestForms", "EmployeeRequestFormId", cascadeDelete: true);
        }
    }
}
