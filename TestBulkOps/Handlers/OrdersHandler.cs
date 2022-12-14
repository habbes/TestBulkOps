using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Handlers
{
    public class OrdersHandler : ODataAPIHandler<Order>
    {
        private AppDbContext db;

        public OrdersHandler(AppDbContext db)
        {
            this.db = db;
        }

        public override IODataAPIHandler? GetNestedHandler(Order parent, string navigationPropertyName)
        {
            return navigationPropertyName switch
            {
                "Customer" => new CustomersHandler(this.db),
                "Product" => new ProductsHandler(this.db),
                _ => null
            };
        }

        public override ODataAPIResponseStatus TryAddRelatedObject(Order resource, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryCreate(IDictionary<string, object> keyValues, out Order createdObject, out string errorMessage)
        {
            createdObject = new Order();
            this.db.Orders.Add(createdObject);
            errorMessage = null;
            return ODataAPIResponseStatus.Success;
        }

        public override ODataAPIResponseStatus TryDelete(IDictionary<string, object> keyValues, out string errorMessage)
        {
            var order = this.db.Orders.Find(keyValues["Id"]);
            errorMessage = null;

            if (order == null)
            {
                return ODataAPIResponseStatus.NotFound;
            }

            this.db.Orders.Remove(order);
            return ODataAPIResponseStatus.Success;
        }

        public override ODataAPIResponseStatus TryGet(IDictionary<string, object> keyValues, out Order originalObject, out string errorMessage)
        {
            originalObject = this.db.Orders.Find(keyValues["Id"]);
            errorMessage = null;

            if (originalObject == null)
            {
                return ODataAPIResponseStatus.NotFound;
            }

            return ODataAPIResponseStatus.Success;
        }
    }
}
