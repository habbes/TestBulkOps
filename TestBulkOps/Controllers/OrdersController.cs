using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using TestBulkOps.Handlers;
using TestBulkOps.Models;

namespace TestBulkOps
{
    public class OrdersController: ODataController
    {
        public IQueryable<Order> Get()
        {
            var orders =  new List<Order>
            {
                new Order { Id = 1, Count = 20 }
            }.AsQueryable();

            return orders;
        }

        public DeltaSet<Order> Patch(DeltaSet<Order> deltaSet)
        {
            var result = deltaSet.Patch(null, new ApiHandlerFactory(this.HttpContext.Request.GetModel()));
            return result;
        }
    }
}
