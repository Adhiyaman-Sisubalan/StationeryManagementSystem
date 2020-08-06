namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeadDelegates",
                c => new
                    {
                        DelegateId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DelegateId)
                .ForeignKey("dbo.Dept_Staff", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HeadDelegates", "UserId", "dbo.Dept_Staff");
            DropIndex("dbo.HeadDelegates", new[] { "UserId" });
            DropTable("dbo.HeadDelegates");
        }
    }
}
