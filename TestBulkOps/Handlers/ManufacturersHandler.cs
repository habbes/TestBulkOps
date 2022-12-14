using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Handlers
{
    public class ManufacturersHandler : ODataAPIHandler<Manufacturer>
    {
        public override IODataAPIHandler GetNestedHandler(Manufacturer parent, string navigationPropertyName)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryAddRelatedObject(Manufacturer resource, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryCreate(IDictionary<string, object> keyValues, out Manufacturer createdObject, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryDelete(IDictionary<string, object> keyValues, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public override ODataAPIResponseStatus TryGet(IDictionary<string, object> keyValues, out Manufacturer originalObject, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
