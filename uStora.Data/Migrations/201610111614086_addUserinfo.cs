namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ApplicationUsers", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ApplicationUsers", "UpdatedBy", c => c.String(maxLength: 128, unicode: false));
            AddColumn("dbo.ApplicationUsers", "CreatedBy", c => c.String(maxLength: 128, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "CreatedBy");
            DropColumn("dbo.ApplicationUsers", "UpdatedBy");
            DropColumn("dbo.ApplicationUsers", "UpdatedDate");
            DropColumn("dbo.ApplicationUsers", "CreatedDate");
        }
    }
}
