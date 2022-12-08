using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Controllers
{
    public class OrdersController : ODataController
    {
        public IQueryable<Order> Get()
        {
            var orders = new List<Order>
            {
                new Order { Id = 1, Count = 20 }
            }.AsQueryable();

            return orders;
        }

        public Order Patch(int key, Delta<Order> order)
        {
            return new Order { Id = key };
        }
    }
}
