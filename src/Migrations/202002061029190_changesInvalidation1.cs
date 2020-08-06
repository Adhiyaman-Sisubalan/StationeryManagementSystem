﻿namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesInvalidation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HeadDelegates", "StartDate", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.HeadDelegates", "EndDate", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HeadDelegates", "EndDate", c => c.String(nullable: false));
            AlterColumn("dbo.HeadDelegates", "StartDate", c => c.String(nullable: false));
        }
    }
}
