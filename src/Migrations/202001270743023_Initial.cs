namespace AD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdjustedItems",
                c => new
                    {
                        AdjustedItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        AdjustedQty = c.Int(nullable: false),
                        AdjustmentVoucher_AdjustmentVoucherId = c.Int(),
                    })
                .PrimaryKey(t => t.AdjustedItemId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.AdjustmentVouchers", t => t.AdjustmentVoucher_AdjustmentVoucherId)
                .Index(t => t.ItemId)
                .Index(t => t.AdjustmentVoucher_AdjustmentVoucherId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemNumber = c.String(),
                        ItemDesc = c.String(maxLength: 50),
                        ItemCategory = c.String(),
                        UnitOfMeasure = c.String(nullable: false),
                        ReorderLevel = c.Int(nullable: false),
                        ReorderQty = c.Int(nullable: false),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.StockDetails",
                c => new
                    {
                        StockDetailsId = c.Int(nullable: false, identity: true),
                        InventoryStockQty = c.Int(nullable: false),
                        ItemQtyChanged = c.Int(nullable: false),
                        DateOfTransaction = c.DateTime(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.StockDetailsId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Suppliers_Price",
                c => new
                    {
                        SuppliersPriceId = c.Int(nullable: false, identity: true),
                        ItemPrice = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.SuppliersPriceId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Item_Id)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        ContactName = c.String(),
                        SupplierAddress = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.AdjustmentVouchers",
                c => new
                    {
                        AdjustmentVoucherId = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        AdjustmentReason = c.String(),
                    })
                .PrimaryKey(t => t.AdjustmentVoucherId);
            
            CreateTable(
                "dbo.CollectionOfRequestedItems",
                c => new
                    {
                        CollectionOfRequestedItemsId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        TotalRequestedQty = c.Int(nullable: false),
                        ConsolidatedRequisition_ConsolidatedRequisitionId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectionOfRequestedItemsId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.ConsolidatedRequisitions", t => t.ConsolidatedRequisition_ConsolidatedRequisitionId)
                .Index(t => t.ItemId)
                .Index(t => t.ConsolidatedRequisition_ConsolidatedRequisitionId);
            
            CreateTable(
                "dbo.CollectionPoints",
                c => new
                    {
                        CollectionPointId = c.Int(nullable: false, identity: true),
                        CollectionPlace = c.String(),
                        CollectionTime = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.CollectionPointId);
            
            CreateTable(
                "dbo.ConsolidatedLists",
                c => new
                    {
                        ConsolidatedListId = c.Int(nullable: false, identity: true),
                        ItemNumber = c.String(),
                        ItemQty = c.Int(nullable: false),
                        CollectonPoint_CollectionPointId = c.Int(),
                        Department_DeptId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsolidatedListId)
                .ForeignKey("dbo.CollectionPoints", t => t.CollectonPoint_CollectionPointId)
                .ForeignKey("dbo.Departments", t => t.Department_DeptId)
                .Index(t => t.CollectonPoint_CollectionPointId)
                .Index(t => t.Department_DeptId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        DeptHead = c.String(),
                        DeptRep = c.String(),
                        CollectionPoint_CollectionPointId = c.Int(),
                    })
                .PrimaryKey(t => t.DeptId)
                .ForeignKey("dbo.CollectionPoints", t => t.CollectionPoint_CollectionPointId)
                .Index(t => t.CollectionPoint_CollectionPointId);
            
            CreateTable(
                "dbo.Dept_Staff",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.EmployeeRequestForms",
                c => new
                    {
                        EmployeeRequestFormId = c.Int(nullable: false, identity: true),
                        EmployeeRequestFormstatus = c.String(),
                        DeptStaff_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeRequestFormId)
                .ForeignKey("dbo.Dept_Staff", t => t.DeptStaff_UserId)
                .Index(t => t.DeptStaff_UserId);
            
            CreateTable(
                "dbo.RequestItems",
                c => new
                    {
                        RequestItemId = c.Int(nullable: false, identity: true),
                        RequestedQty = c.Int(nullable: false),
                        EmployeeRequestFormId = c.Int(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RequestItemId)
                .ForeignKey("dbo.EmployeeRequestForms", t => t.EmployeeRequestFormId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.EmployeeRequestFormId)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ConsolidatedRequisitions",
                c => new
                    {
                        ConsolidatedRequisitionId = c.Int(nullable: false, identity: true),
                        deptId = c.Int(),
                        ConsolidatedRequisitionStatus = c.String(),
                        CollectionPointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsolidatedRequisitionId)
                .ForeignKey("dbo.CollectionPoints", t => t.CollectionPointId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.deptId)
                .Index(t => t.deptId)
                .Index(t => t.CollectionPointId);
            
            CreateTable(
                "dbo.DisburseItems",
                c => new
                    {
                        DisburseItemId = c.Int(nullable: false, identity: true),
                        DisburseQty = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        DisbursementList_DisbursementListId = c.Int(),
                    })
                .PrimaryKey(t => t.DisburseItemId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.DisbursementLists", t => t.DisbursementList_DisbursementListId)
                .Index(t => t.Item_Id)
                .Index(t => t.DisbursementList_DisbursementListId);
            
            CreateTable(
                "dbo.DisbursementLists",
                c => new
                    {
                        DisbursementListId = c.Int(nullable: false, identity: true),
                        DisbursementListDate = c.DateTime(nullable: false),
                        Department_DeptId = c.Int(),
                    })
                .PrimaryKey(t => t.DisbursementListId)
                .ForeignKey("dbo.Departments", t => t.Department_DeptId)
                .Index(t => t.Department_DeptId);
            
            CreateTable(
                "dbo.PurchaseItems",
                c => new
                    {
                        PurchaseItemId = c.Int(nullable: false, identity: true),
                        PurchaseQty = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        PurchaseOrder_PurchaseOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseItemId)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_PurchaseOrderId)
                .Index(t => t.Item_Id)
                .Index(t => t.PurchaseOrder_PurchaseOrderId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false, identity: true),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseOrderId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Store_Staff",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        store_storeId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Stores", t => t.store_storeId)
                .Index(t => t.store_storeId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        storeId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.storeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Store_Staff", "store_storeId", "dbo.Stores");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PurchaseOrders", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseItems", "PurchaseOrder_PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.DisburseItems", "DisbursementList_DisbursementListId", "dbo.DisbursementLists");
            DropForeignKey("dbo.DisbursementLists", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.DisburseItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ConsolidatedRequisitions", "deptId", "dbo.Departments");
            DropForeignKey("dbo.ConsolidatedRequisitions", "CollectionPointId", "dbo.CollectionPoints");
            DropForeignKey("dbo.CollectionOfRequestedItems", "ConsolidatedRequisition_ConsolidatedRequisitionId", "dbo.ConsolidatedRequisitions");
            DropForeignKey("dbo.ConsolidatedLists", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.RequestItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.RequestItems", "EmployeeRequestFormId", "dbo.EmployeeRequestForms");
            DropForeignKey("dbo.EmployeeRequestForms", "DeptStaff_UserId", "dbo.Dept_Staff");
            DropForeignKey("dbo.Dept_Staff", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "CollectionPoint_CollectionPointId", "dbo.CollectionPoints");
            DropForeignKey("dbo.ConsolidatedLists", "CollectonPoint_CollectionPointId", "dbo.CollectionPoints");
            DropForeignKey("dbo.CollectionOfRequestedItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.AdjustedItems", "AdjustmentVoucher_AdjustmentVoucherId", "dbo.AdjustmentVouchers");
            DropForeignKey("dbo.AdjustedItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Suppliers_Price", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Items", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers_Price", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.StockDetails", "Item_Id", "dbo.Items");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Store_Staff", new[] { "store_storeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PurchaseOrders", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.PurchaseItems", new[] { "PurchaseOrder_PurchaseOrderId" });
            DropIndex("dbo.PurchaseItems", new[] { "Item_Id" });
            DropIndex("dbo.DisbursementLists", new[] { "Department_DeptId" });
            DropIndex("dbo.DisburseItems", new[] { "DisbursementList_DisbursementListId" });
            DropIndex("dbo.DisburseItems", new[] { "Item_Id" });
            DropIndex("dbo.ConsolidatedRequisitions", new[] { "CollectionPointId" });
            DropIndex("dbo.ConsolidatedRequisitions", new[] { "deptId" });
            DropIndex("dbo.RequestItems", new[] { "Item_Id" });
            DropIndex("dbo.RequestItems", new[] { "EmployeeRequestFormId" });
            DropIndex("dbo.EmployeeRequestForms", new[] { "DeptStaff_UserId" });
            DropIndex("dbo.Dept_Staff", new[] { "DeptId" });
            DropIndex("dbo.Departments", new[] { "CollectionPoint_CollectionPointId" });
            DropIndex("dbo.ConsolidatedLists", new[] { "Department_DeptId" });
            DropIndex("dbo.ConsolidatedLists", new[] { "CollectonPoint_CollectionPointId" });
            DropIndex("dbo.CollectionOfRequestedItems", new[] { "ConsolidatedRequisition_ConsolidatedRequisitionId" });
            DropIndex("dbo.CollectionOfRequestedItems", new[] { "ItemId" });
            DropIndex("dbo.Suppliers_Price", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Suppliers_Price", new[] { "Item_Id" });
            DropIndex("dbo.StockDetails", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.AdjustedItems", new[] { "AdjustmentVoucher_AdjustmentVoucherId" });
            DropIndex("dbo.AdjustedItems", new[] { "ItemId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Stores");
            DropTable("dbo.Store_Staff");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseItems");
            DropTable("dbo.DisbursementLists");
            DropTable("dbo.DisburseItems");
            DropTable("dbo.ConsolidatedRequisitions");
            DropTable("dbo.RequestItems");
            DropTable("dbo.EmployeeRequestForms");
            DropTable("dbo.Dept_Staff");
            DropTable("dbo.Departments");
            DropTable("dbo.ConsolidatedLists");
            DropTable("dbo.CollectionPoints");
            DropTable("dbo.CollectionOfRequestedItems");
            DropTable("dbo.AdjustmentVouchers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Suppliers_Price");
            DropTable("dbo.StockDetails");
            DropTable("dbo.Items");
            DropTable("dbo.AdjustedItems");
        }
    }
}
