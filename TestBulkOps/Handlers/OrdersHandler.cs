using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Handlers
{
    public class OrdersHandler : ODataAPIHandler<Order>
    {
        public override IODataAPIHandler? GetNestedHandler(Order parent, string navigationPropertyName)
        {
            return navigationPropertyName switch
            {
                "Customer" => new CustomersHandler(),
                "Product" => new ProductsHandler(),
                _ => null
            };
        }

        public override ODataAPIResponseStatus TryCreate(IDictionary<string, object> keyValues, out Order createdObject, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryDelete(IDictionary<string, object> keyValues, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryGet(IDictionary<string, object> keyValues, out Order originalObject, out string errorMessage)
        {
            throw new NotImplementedException();
            //originalObject = null;
            //errorMessage = "";
            //return ODataAPIResponseStatus.NotFound;
        }
    }
}
