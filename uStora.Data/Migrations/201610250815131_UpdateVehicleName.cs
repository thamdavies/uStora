namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVehicleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Name");
        }
    }
}
