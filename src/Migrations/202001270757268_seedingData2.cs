namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingData2 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Dept_Staff(Username,Password,Role,DeptId)" +
                            "values('Chandler','chandler','Employee','1'),('Racheal','chandler','Representative','1')");
            Sql("Insert into Items(ItemNumber,itemDesc,unitOfMeasure,reorderLevel,reorderQty,ItemCategory) values('C001','Clip Single 1','Dozen',50,30,'Clips')");
            Sql("Insert into Items(ItemNumber,itemDesc,unitOfMeasure,reorderLevel,reorderQty,ItemCategory) values('C002','Clip Single 1','Dozen',50,30,'Clips')");
        }
        
        public override void Down()
        {
        }
    }
}
