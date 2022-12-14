using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Handlers
{
    public class ProductsHandler : ODataAPIHandler<Product>
    {
        private AppDbContext db;

        public ProductsHandler(AppDbContext db)
        {
            this.db = db;
        }

        public override IODataAPIHandler GetNestedHandler(Product parent, string navigationPropertyName)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryAddRelatedObject(Product resource, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryCreate(IDictionary<string, object> keyValues, out Product createdObject, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryDelete(IDictionary<string, object> keyValues, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryGet(IDictionary<string, object> keyValues, out Product originalObject, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
