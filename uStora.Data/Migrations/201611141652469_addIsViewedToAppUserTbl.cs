namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsViewedToAppUserTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "IsViewed", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "IsViewed");
        }
    }
}
