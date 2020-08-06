namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLOgin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Store_Staff", "store_storeId", "dbo.Stores");
            DropIndex("dbo.Store_Staff", new[] { "store_storeId" });
            RenameColumn(table: "dbo.Store_Staff", name: "store_storeId", newName: "storeId");
            AddColumn("dbo.Stores", "StoreName", c => c.String());
            AlterColumn("dbo.Store_Staff", "storeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Store_Staff", "storeId");
            AddForeignKey("dbo.Store_Staff", "storeId", "dbo.Stores", "storeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Store_Staff", "storeId", "dbo.Stores");
            DropIndex("dbo.Store_Staff", new[] { "storeId" });
            AlterColumn("dbo.Store_Staff", "storeId", c => c.Int());
            DropColumn("dbo.Stores", "StoreName");
            RenameColumn(table: "dbo.Store_Staff", name: "storeId", newName: "store_storeId");
            CreateIndex("dbo.Store_Staff", "store_storeId");
            AddForeignKey("dbo.Store_Staff", "store_storeId", "dbo.Stores", "storeId");
        }
    }
}
