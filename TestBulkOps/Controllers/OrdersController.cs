using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
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

        public DeltaSet<Order> Patch(DeltaSet<Order> deltaSet)
        {
            var result = deltaSet.Patch(null, new ApiHandlerFactory(this.HttpContext.Request.GetModel(), this.db));
            db.SaveChanges();
            return result;
        }
    }
}
