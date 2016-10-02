namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSlide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slides", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Slides", "CreatedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Slides", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Slides", "UpdatedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.Slides", "MetaKeyword", c => c.String(maxLength: 150));
            AddColumn("dbo.Slides", "MetaDescription", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slides", "MetaDescription");
            DropColumn("dbo.Slides", "MetaKeyword");
            DropColumn("dbo.Slides", "UpdatedBy");
            DropColumn("dbo.Slides", "UpdatedDate");
            DropColumn("dbo.Slides", "CreatedBy");
            DropColumn("dbo.Slides", "CreatedDate");
        }
    }
}
