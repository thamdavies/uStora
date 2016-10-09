namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUsers", "FullName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ApplicationUsers", "Gender", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUsers", "Gender", c => c.String(maxLength: 5));
            AlterColumn("dbo.ApplicationUsers", "FullName", c => c.String(maxLength: 256));
        }
    }
}
