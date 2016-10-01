namespace uStora.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedWishListTbl : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => new { t.ID, t.ProductID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "ProductID", "dbo.Products");
            DropIndex("dbo.WishLists", new[] { "ProductID" });
            DropTable("dbo.WishLists");
        }
    }
}