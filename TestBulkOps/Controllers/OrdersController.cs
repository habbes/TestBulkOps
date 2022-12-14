using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using TestBulkOps.Handlers;
using TestBulkOps.Models;

namespace TestBulkOps
{
    public class OrdersController: ODataController
    {
        AppDbContext db;
        public OrdersController(AppDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Order> Get()
        {
            return db.Orders;
        }

        public Order Post([FromBody] Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        public DeltaSet<Order> Patch(DeltaSet<Order> deltaSet)
        {
            var result = deltaSet.Patch(null, new ApiHandlerFactory(this.HttpContext.Request.GetModel(), this.db));
            db.SaveChanges();
            return result;
        }
    }
}
