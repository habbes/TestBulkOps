using Microsoft.AspNet.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;

namespace TestBulkOps.Handlers
{
    public class ApiHandlerFactory : ODataAPIHandlerFactory
    {
        public ApiHandlerFactory(IEdmModel model): base(model) { }
        public override IODataAPIHandler GetHandler(ODataPath odataPath)
        {
            if (odataPath.LastSegment.EdmType.AsElementType() is IEdmStructuredType structuredType)
            {
                string fullName = structuredType.FullTypeName();
                if (fullName.EndsWith(".Customer"))
                {
                    return new CustomersHandler();
                }

                //if (fullName.EndsWith(".Order"))
                //{
                //    return new OrdersHandler();
                //}
            }

            return null;
        }
    }
}
