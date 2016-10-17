namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveWishListTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WishLists", "ProductID", "dbo.Products");
            DropIndex("dbo.WishLists", new[] { "ProductID" });
            DropTable("dbo.WishLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                        MetaKeyword = c.String(maxLength: 150),
                        MetaDescription = c.String(maxLength: 150),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.ProductID });
            
            CreateIndex("dbo.WishLists", "ProductID");
            AddForeignKey("dbo.WishLists", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
