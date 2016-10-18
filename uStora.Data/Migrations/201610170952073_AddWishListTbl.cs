namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWishListTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.Long(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                        MetaKeyword = c.String(maxLength: 150),
                        MetaDescription = c.String(maxLength: 150),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishlists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Wishlists", "UserId", "dbo.ApplicationUsers");
            DropIndex("dbo.Wishlists", new[] { "ProductId" });
            DropIndex("dbo.Wishlists", new[] { "UserId" });
            DropTable("dbo.Wishlists");
        }
    }
}
