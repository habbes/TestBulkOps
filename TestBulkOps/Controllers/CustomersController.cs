using Microsoft.AspNet.OData;
using TestBulkOps.Models;

namespace TestBulkOps.Controllers
{
    public class CustomersController : ODataController
    {
        public AppDbContext db;

        public CustomersController(AppDbContext db)
        { 
            this.db = db; 
        }

        public Customer Post(Customer customer)
        {
            db.Customers.Add(customer);
            return customer;
        }

        [EnableQuery]
        public Customer Get(int key)
        {
            return db.Customers.Find(key);
        }

        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return db.Customers;
        }
    }
}
