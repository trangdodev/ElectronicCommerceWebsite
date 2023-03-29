namespace Doanweb1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeproductdetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail");
            DropForeignKey("dbo.ProductDetail", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductDetail", new[] { "ProductId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductDetailId" });
            DropPrimaryKey("dbo.OrderDetail");
            AddColumn("dbo.OrderDetail", "ProductId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderDetail", new[] { "OrderId", "ProductId" });
            CreateIndex("dbo.OrderDetail", "ProductId");
            AddForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product", "ProductId");
            DropColumn("dbo.OrderDetail", "ProductDetailId");
            DropTable("dbo.ProductDetail");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ProductDetailId);
            
            AddColumn("dbo.OrderDetail", "ProductDetailId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropPrimaryKey("dbo.OrderDetail");
            DropColumn("dbo.OrderDetail", "ProductId");
            AddPrimaryKey("dbo.OrderDetail", new[] { "OrderId", "ProductDetailId" });
            CreateIndex("dbo.OrderDetail", "ProductDetailId");
            CreateIndex("dbo.ProductDetail", "ProductId");
            AddForeignKey("dbo.ProductDetail", "ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail", "ProductDetailId");
        }
    }
}
