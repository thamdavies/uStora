namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerMobile", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerMobile", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
