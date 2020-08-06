namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Some : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeRequestForms", "DeptId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeRequestForms", "DeptId");
        }
    }
}
