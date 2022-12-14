using Microsoft.AspNet.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using TestBulkOps.Models;

namespace TestBulkOps.Handlers
{
    public class ApiHandlerFactory : ODataAPIHandlerFactory
    {
        private AppDbContext db;
        public ApiHandlerFactory(IEdmModel model, AppDbContext dbContext): base(model)
        {
            this.db = dbContext;
        }
        public override IODataAPIHandler GetHandler(ODataPath odataPath)
        {
            if (odataPath.LastSegment.EdmType.AsElementType() is IEdmStructuredType structuredType)
            {
                string fullName = structuredType.FullTypeName();
                if (fullName.EndsWith(".Customer"))
                {
                    return new CustomersHandler(this.db);
                }

                if (fullName.EndsWith(".Order"))
                {
                    return new OrdersHandler(this.db);
                }
            }

            return null;
        }
    }
}
