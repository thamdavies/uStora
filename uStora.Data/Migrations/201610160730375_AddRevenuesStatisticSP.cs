namespace uStora.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddRevenuesStatisticSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetRevenuesStatistic",
                p => new
                {
                    fromDate = p.String(),
                    toDate = p.String()
                }
                ,
                @"select o.CreatedDate as Date,
                    SUM(od.Price* od.Quantity) as Revenues,
                    SUM((od.Price* od.Quantity)-(p.OriginalPrice*od.Quantity)) as Benefit
                    from Orders o
                    inner join OrderDetails od
                    on o.ID = od.OrderID
                    inner join Products p
                    on od.ProductID = p.ID
                    where o.CreatedDate >= CAST(@fromDate as date) and o.CreatedDate <= CAST(@toDate as date)
                    group by o.CreatedDate"
                );
        }

        public override void Down()
        {
            DropStoredProcedure("dbo.GetRevenuesStatistic");
        }
    }
}