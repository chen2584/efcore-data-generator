using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestEf.Models;

namespace TestEf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        readonly TestDbContext db;

        public ValuesController(TestDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customers>> Get()
        {
            return db.Customers;
        }

        [HttpGet("testId")]
        public ActionResult<string> Get([Required] int id)
        {
            return $"Id: {id}";
        }

        [HttpGet("createdb")]
        public ActionResult CreteDatabase()
        {
            db.Database.EnsureCreated();
            db.Customers.Add(new Customers
            {
                FirstName = "FirstName01",
                UniqueId = 1,
                LastName = "LastName01"
            });
            db.Customers.Add(new Customers
            {
                FirstName = "FirstName02",
                UniqueId = 2,
                LastName = "LastName02"
            });
            db.Customers.Add(new Customers
            {
                FirstName = "FirstName03",
                UniqueId = 3,
                LastName = "LastName03"
            });

            db.SaveChanges();
            return Ok("Created");
        }

        [HttpGet("dropdb")]
        public ActionResult DropDatabase(int num)
        {
            db.Database.EnsureDeleted();
            return Ok("Dropped");
        }

        [HttpGet("insert")]
        public ActionResult InsertData(int num)
        {
            db.Customers.Add(new Customers {
                FirstName = "FirstName555",
                UniqueId = 1,
                LastName = "LastName555"
            });
            db.SaveChanges();
            return Ok("Added");
        }

        [HttpGet("update")]
        public ActionResult UpdateTable(int num)
        {
            var customer = db.Customers.FirstOrDefault();
            customer.FirstName = Guid.NewGuid().ToString();
            db.SaveChanges();
            return Ok("Updated");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
