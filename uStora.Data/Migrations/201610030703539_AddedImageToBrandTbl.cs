namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageToBrandTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "Image", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "Image");
        }
    }
}
