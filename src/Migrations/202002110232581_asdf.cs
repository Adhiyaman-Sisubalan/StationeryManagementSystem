namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrendAnalysis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrendAnalysis");
        }
    }
}
