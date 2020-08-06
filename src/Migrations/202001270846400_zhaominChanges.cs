namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zhaominChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dept_Staff", "Staff_Status", c => c.String());
            AddColumn("dbo.EmployeeRequestForms", "RequestSubmissionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeRequestForms", "RequestSubmissionDate");
            DropColumn("dbo.Dept_Staff", "Staff_Status");
        }
    }
}
