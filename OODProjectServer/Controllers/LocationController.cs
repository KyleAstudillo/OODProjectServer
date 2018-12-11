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
    [Route("api/location")]
    public class LocationController : Controller
    {
        private SqlHelper sqlHelper;

        public LocationController()
        {
            sqlHelper = new SqlHelper();
        }

        // GET: api/location
        [HttpGet]
        public List<LocationItem> GetAll()
        {
            return sqlHelper.getAllLocationItems();
        }

        // GET api/location/5
        [HttpGet("{id}", Name ="location")]
        public ActionResult Get(int id)
        {
            var item = sqlHelper.GetLocationItemByID(id);
            if (item == null || item.Count <= 0)
            {
                return NotFound();
            }
            return new JsonResult(item[0]);
        }

        // POST api/location
        [HttpPost]
        public IActionResult Post(LocationItem item)
        {
            int result = sqlHelper.putLocationItem(item);
            if (result == 0)
            {
                return CreatedAtRoute("location", new { id = item.Id }, item);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/location/5
        [HttpDelete("{id}", Name = "location")]
        public ActionResult Delete(int id)
        {
            var item = sqlHelper.GetLocationItemByID(id);
            if (item == null || item.Count == 0)
            {
                return NotFound();
            }
            sqlHelper.DeleteLocationItem(item[0]);
            return NoContent();
        }
    }
}
