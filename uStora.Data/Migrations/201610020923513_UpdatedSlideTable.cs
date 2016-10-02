namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSlideTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slides", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slides", "Content", c => c.String(nullable: false));
        }
    }
}
