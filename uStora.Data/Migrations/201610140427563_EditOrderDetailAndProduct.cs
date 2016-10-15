namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderDetailAndProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Products", "OriginalPrice");
            DropColumn("dbo.OrderDetails", "Price");
        }
    }
}
