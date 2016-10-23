namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPageDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Pages", "CreatedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Pages", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Pages", "UpdatedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Pages", "MetaKeyword", c => c.String(maxLength: 150));
            AddColumn("dbo.Pages", "MetaDescription", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.Pages", "MetaKeyword");
            DropColumn("dbo.Pages", "UpdatedBy");
            DropColumn("dbo.Pages", "UpdatedDate");
            DropColumn("dbo.Pages", "CreatedBy");
            DropColumn("dbo.Pages", "CreatedDate");
        }
    }
}
