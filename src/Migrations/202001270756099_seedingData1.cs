namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingData1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into CollectionPoints(CollectionPlace,CollectionTime) values('ISS','12/12/20'),('COM2','12/12/20'),('IT','12/12/20')");
            Sql("Insert into Departments(DeptName,DeptHead,DeptRep,CollectionPoint_CollectionPointId) values('Commerce','Ross','Mike',1),('English','Chandler','Neha',2)");
        }
        
        public override void Down()
        {
        }
    }
}
