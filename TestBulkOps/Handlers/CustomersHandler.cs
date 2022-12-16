using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Handlers
{
    public class CustomersHandler : ODataAPIHandler<Customer>
    {
        AppDbContext db;
        public CustomersHandler(AppDbContext db)
        {
            this.db = db;
        }
        public override IODataAPIHandler GetNestedHandler(Customer parent, string navigationPropertyName)
        {
            return null;
        }

        public override ODataAPIResponseStatus TryAddRelatedObject(Customer resource, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryCreate(IDictionary<string, object> keyValues, out Customer createdObject, out string errorMessage)
        {
            createdObject = new Customer();
            errorMessage = null;
            db.Customers.Add(createdObject);
            return ODataAPIResponseStatus.Success;
        }

        public override ODataAPIResponseStatus TryDelete(IDictionary<string, object> keyValues, out string errorMessage)
        {
            var customer = db.Customers.Find(keyValues["Id"]);
            errorMessage = null;
            if (customer == null)
            {
                return ODataAPIResponseStatus.NotFound;
            }

            db.Customers.Remove(customer);
            return ODataAPIResponseStatus.Success;
        }

        public override ODataAPIResponseStatus TryGet(IDictionary<string, object> keyValues, out Customer originalObject, out string errorMessage)
        {
            try {
                originalObject = keyValues["Id"] == "Null" ? null : db.Customers.Find(keyValues["Id"]);
                errorMessage = null;

                if (originalObject == null)
                {
                    return ODataAPIResponseStatus.NotFound;
                }

                return ODataAPIResponseStatus.Success;
            }
            catch (Exception ex)
            {
                originalObject = null;
                errorMessage = ex.Message;
                return ODataAPIResponseStatus.Failure;
            }
        }
    }
}
