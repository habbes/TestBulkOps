using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using TestBulkOps.Models;

namespace TestBulkOps.Controllers
{
    public class ProductsController: ODataController
    {
        public AppDbContext db;

        public ProductsController(AppDbContext db)
        {
            this.db = db;
        }

        public Product Post([FromBody] Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        [EnableQuery]
        public Product Get(int key)
        {
            return db.Products.Find(key);
        }

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.Products;
        }
    }
}
