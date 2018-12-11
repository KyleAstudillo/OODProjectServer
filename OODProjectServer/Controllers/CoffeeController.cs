using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using OODProjectServer.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections;
using System.Diagnostics;
using OODProjectServer.Entities;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OODProjectServer.Controllers
{
    [Produces("application/json")]
    [Route("api/coffee")]
    public class CoffeeController : Controller
    {
        private CoffeeContext _context;

        //TODO inject S3 Client
        public CoffeeController(CoffeeContext context)
        {
            _context = context;

           // Create a new TodoItem if collection is empty,
           // which means you can't delete all TodoItems.

            //string link1 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZjphQje8agD2NHCefLRzk8xdsU4kL_XlypgeublZoZAZxJhL6fw";
            //string link2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSGbiv-DkWtSVw3Ir_6FNer3S9vB6dI6PN0ZVWhfhQnZp7EyApy";
            //string link3 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQctidq7Ig44_Enhj52pcPC0i8BxsE2RT0BaTKuuL8TjvD4rWMLkA";
        }

        // GET: api/coffee
        [HttpGet]
        public List<CoffeeItem> GetAll()
        {
            //return sqlHelper.getAllCoffeeItems();
            return _context.CoffeeItems.ToList();
        }

        // GET api/coffee/5
        [HttpGet("{id}", Name ="coffee")]
        public ActionResult Get(int id)
        {
            var item = _context.CoffeeItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new JsonResult(item);
        }

        // POST api/coffee
        [Authorize]
        [HttpPost]
        public IActionResult Post(CoffeeItem item)
        {
            CoffeeItem exist = _context.CoffeeItems.Find(item.Id);
            if (exist == null)
            {
                _context.CoffeeItems.Add(item);
                _context.SaveChanges();
                return CreatedAtRoute("coffee", new { id = item.Id }, item);
            }
            else
            {
                Debug.Print("SERVER INFO item name:" + item.Name);
                exist.Name = item.Name;
                _context.SaveChanges();
                return CreatedAtRoute("coffee", new { id = item.Id }, item);
            }
        }

        // DELETE api/coffee/5
        [Authorize]
        [HttpDelete("{id}", Name = "coffee")]
        public ActionResult Delete(int id)
        {
            CoffeeItem item = _context.CoffeeItems.Find(id);
            if (item != null)
            {
                _context.CoffeeItems.Remove(item);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
