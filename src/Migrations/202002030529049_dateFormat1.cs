﻿namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateFormat1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HeadDelegates", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HeadDelegates", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HeadDelegates", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HeadDelegates", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
