namespace Doanweb1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Delivery", "DeliveryDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Delivery", "DeliveryDate", c => c.DateTime());
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
