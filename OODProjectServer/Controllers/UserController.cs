using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OODProjectServer.Helpers;
using OODProjectServer.Entities;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OODProjectServer.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private CoffeeContext _context;

        public UserController(CoffeeContext context)
        {
            _context = context;
        }
        // GET: api/user
        [HttpGet]
        public List<UserItem> GetAll()
        {
            return _context.UserItems.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}", Name = "user")]
        public ActionResult Get(int id)
        {
            UserItem user = _context.UserItems.Find(id);
            List<CoffeeItem> coffeeItems = new List<CoffeeItem>();
            foreach (CoffeeItem item in _context.CoffeeItems)
            {
                if (item.UserId == user.UserId)
                {
                    coffeeItems.Add(item);
                }
            }
            user.CoffeeItems = coffeeItems.ToList();
            _context.SaveChanges();
            return new JsonResult(user);
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post(UserItem item)
        {
            _context.UserItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("user", new { id = item.Id }, item);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            UserItem item = _context.UserItems.Find(id);
            if (item != null)
            {
                _context.UserItems.Remove(item);
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
