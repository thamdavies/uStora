namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrackTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Longitude = c.String(),
                        Latitude = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.VehicleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleNumber = c.String(maxLength: 30, unicode: false),
                        DriverName = c.String(maxLength: 100),
                        ModelID = c.String(maxLength: 50),
                        Model = c.String(maxLength: 150),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                        MetaKeyword = c.String(maxLength: 150),
                        MetaDescription = c.String(maxLength: 150),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackOrders", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.TrackOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.TrackOrders", "UserId", "dbo.ApplicationUsers");
            DropIndex("dbo.TrackOrders", new[] { "UserId" });
            DropIndex("dbo.TrackOrders", new[] { "VehicleId" });
            DropIndex("dbo.TrackOrders", new[] { "OrderId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.TrackOrders");
        }
    }
}
