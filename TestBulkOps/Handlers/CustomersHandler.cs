using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Handlers
{
    public class CustomersHandler : ODataAPIHandler<Customer>
    {
        public override IODataAPIHandler GetNestedHandler(Customer parent, string navigationPropertyName)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryCreate(IDictionary<string, object> keyValues, out Customer createdObject, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryDelete(IDictionary<string, object> keyValues, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryGet(IDictionary<string, object> keyValues, out Customer originalObject, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
