using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoFirstSample.Models;

namespace MongoFirstSample.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        DataAccess objds;

        public UserController(DataAccess d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return objds.GetUsers();
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var product = objds.GetUser(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]User p)
        {
            var recId = new ObjectId(id);
            var product = objds.GetUser(recId);
            if (product == null)
            {
                return NotFound();
            }

            objds.Update(recId, p);
            return new OkResult();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = objds.GetUser(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }

            objds.Remove(product.Id);
            return new OkResult();
        }
    }
}
