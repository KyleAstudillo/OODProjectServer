using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OODProjectServer.Helpers;
using OODProjectServer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OODProjectServer.Controllers
{
    [Produces("application/json")]
    //[Authorize]
    [Route("api/inventory")]
    public class InventoryController : Controller
    {
        private SqlHelper sqlHelper;

        public InventoryController()
        {
            sqlHelper = new SqlHelper();
        }

        // GET: api/inventory
        [HttpGet]
        public List<InventoryItem> GetAll()
        {
            return sqlHelper.getAllInventoryItems();
        }

        // GET api/inventory/5
        [HttpGet("{id}", Name ="inventory")]
        public ActionResult Get(int id)
        {
            var item = sqlHelper.GetInventoryItemByID(id);
            if (item == null || item.Count <= 0)
            {
                return NotFound();
            }
            return new JsonResult(item[0]);
        }

        // POST api/inventory
        [HttpPost]
        public IActionResult Post(InventoryItem item)
        {
            int result = sqlHelper.putInventoryItem(item);
            if (result == 0)
            {
                return CreatedAtRoute("inventory", new { id = item.Id }, item);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/inventory/5
        [HttpDelete("{id}", Name = "inventory")]
        public ActionResult Delete(int id)
        {
            var item = sqlHelper.GetInventoryItemByID(id);
            if (item == null || item.Count == 0)
            {
                return NotFound();
            }
            sqlHelper.DeleteInventoryItem(item[0]);
            return NoContent();
        }
    }
}
