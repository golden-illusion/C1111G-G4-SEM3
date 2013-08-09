namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        CustomerName = c.String(nullable: false, maxLength: 40),
                        CustomerAddress = c.String(nullable: false, maxLength: 100),
                        CustomerPhone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleName = c.String(nullable: false, maxLength: 50),
                        VehicleNumber = c.String(nullable: false, maxLength: 15),
                        VehicleModel = c.String(nullable: false, maxLength: 20),
                        VehicleVersion = c.Int(nullable: false),
                        VehicleBodyNumber = c.String(nullable: false, maxLength: 20),
                        VehicleEngineNumber = c.String(nullable: false, maxLength: 20),
                        VehicleWarranty = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        TestimonialDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestimonialId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        PolicyType = c.String(nullable: false, maxLength: 50),
                        PolicyDuration = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        PolicyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PolicyId);
            
            CreateTable(
                "dbo.CustomerPolicies",
                c => new
                    {
                        CustPolicyId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        PolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustPolicyId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        AccidentPlace = c.String(nullable: false, maxLength: 100),
                        AccidentDate = c.DateTime(nullable: false),
                        InsuredAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClaimableAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustPolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.CustomerPolicies", t => t.CustPolicyId, cascadeDelete: true)
                .Index(t => t.CustPolicyId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillNo = c.Int(nullable: false, identity: true),
                        CustomerAddProve = c.String(nullable: false, maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustPolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillNo)
                .ForeignKey("dbo.CustomerPolicies", t => t.CustPolicyId, cascadeDelete: true)
                .Index(t => t.CustPolicyId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        ExpenseType = c.String(nullable: false, maxLength: 50),
                        ExpenseDate = c.DateTime(nullable: false),
                        ExpenseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bills", new[] { "CustPolicyId" });
            DropIndex("dbo.Claims", new[] { "CustPolicyId" });
            DropIndex("dbo.CustomerPolicies", new[] { "PolicyId" });
            DropIndex("dbo.CustomerPolicies", new[] { "VehicleId" });
            DropIndex("dbo.Testimonials", new[] { "CustomerId" });
            DropIndex("dbo.Vehicles", new[] { "CustomerId" });
            DropForeignKey("dbo.Bills", "CustPolicyId", "dbo.CustomerPolicies");
            DropForeignKey("dbo.Claims", "CustPolicyId", "dbo.CustomerPolicies");
            DropForeignKey("dbo.CustomerPolicies", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.CustomerPolicies", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Testimonials", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Vehicles", "CustomerId", "dbo.Customers");
            DropTable("dbo.Admins");
            DropTable("dbo.Expenses");
            DropTable("dbo.Bills");
            DropTable("dbo.Claims");
            DropTable("dbo.CustomerPolicies");
            DropTable("dbo.Policies");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Customers");
        }
    }
}
