namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adhiiiii : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Items", "CurrentQty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "CurrentQty");
            DropTable("dbo.Points");
        }
    }
}
