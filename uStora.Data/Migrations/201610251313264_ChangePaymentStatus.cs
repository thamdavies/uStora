namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePaymentStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "PaymentStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "PaymentStatus", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
