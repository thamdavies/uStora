namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "Image", c => c.String(maxLength: 256, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "Image");
        }
    }
}
