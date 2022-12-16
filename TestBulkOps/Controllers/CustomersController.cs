using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestBulkOps.Handlers;
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

        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
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

        public DeltaSet<Customer> Patch(DeltaSet<Customer> deltaSet)
        {
            var result = deltaSet.Patch(null, new ApiHandlerFactory(this.HttpContext.Request.GetModel(), this.db));
            db.SaveChanges();
            return result;
        }
    }
}
