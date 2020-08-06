namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Points");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        PointId = c.Int(nullable: false, identity: true),
                        x = c.String(),
                        y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PointId);
            
        }
    }
}
