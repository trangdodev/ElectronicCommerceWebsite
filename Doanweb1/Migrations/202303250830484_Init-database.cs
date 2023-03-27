namespace Doanweb1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(maxLength: 200),
                        LogoUrl = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 200),
                        Quantity = c.Int(nullable: false),
                        OriginPrice = c.Decimal(precision: 18, scale: 0),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        Rating = c.Double(),
                        ImageUrl = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Brand", t => t.BrandId)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 200),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductDetail",
                c => new
                    {
                        ProductDetailId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Variant = c.String(maxLength: 50),
                        VariantPrice = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ProductDetailId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductDetailId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductDetailId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.ProductDetail", t => t.ProductDetailId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductDetailId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        OrderDate = c.DateTime(nullable: false),
                        IsComplete = c.Boolean(),
                        IsPaid = c.Boolean(),
                        TransactionId = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Delivery", t => t.OrderId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(),
                        Address = c.String(nullable: false, maxLength: 500),
                        PhoneNumber = c.String(nullable: false, maxLength: 12),
                        CustomerName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DeliveryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.ProductDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "OrderId", "dbo.Delivery");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Order", new[] { "OrderId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductDetailId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.ProductDetail", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "BrandId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropTable("dbo.Delivery");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.ProductDetail");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Brand");
        }
    }
}
