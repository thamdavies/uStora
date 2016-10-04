namespace uStora.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeedback : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "Website", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Feedbacks", "Phone", c => c.String(maxLength: 20, unicode: false));
            AddColumn("dbo.Feedbacks", "Address", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "Address");
            DropColumn("dbo.Feedbacks", "Phone");
            DropColumn("dbo.Feedbacks", "Website");
        }
    }
}
