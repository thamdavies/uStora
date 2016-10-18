namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSystemConfig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SystemConfigs", "ValueString", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SystemConfigs", "ValueString", c => c.String(maxLength: 50));
        }
    }
}
