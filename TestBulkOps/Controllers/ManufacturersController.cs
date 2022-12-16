using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using TestBulkOps.Models;

namespace TestBulkOps.Controllers
{
    public class ManufacturersController : ODataController
    {
        public AppDbContext db;

        public ManufacturersController(AppDbContext db)
        {
            this.db = db;
        }

        public Manufacturer Post([FromBody] Manufacturer manufacturer)
        {
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
            return manufacturer;
        }

        [EnableQuery]
        public Manufacturer Get(int key)
        {
            return db.Manufacturers.Find(key);
        }

        [EnableQuery]
        public IQueryable<Manufacturer> Get()
        {
            return db.Manufacturers;
        }
    }
}
