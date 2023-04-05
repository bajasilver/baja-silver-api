using Microsoft.AspNetCore.Mvc;
using Baja.Silver.Domain.Catalog;
using Baja.Silver.Data;
using Microsoft.EntityFrameworkCore;

namespace Baja.Silver.Api.Controllers {
    [ApiController]
    //[Route("[controller]")]
    [Route("/catalog")]
    public class CatalogController : ControllerBase 
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetItems() 
        {
            return Ok(_db.Items);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id) 
        {
            // var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            // item.Id = id;

            var item = _db.Items.Find(id);
            if (item == null) 
            {
                return NotFound();
            }

            //return Ok(_db.Items.Find(id));
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(Item item) {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
            //return Created("/catalog/42", item);
            
            //test for post
            // { "name": "Shoes",
            // "description": "Running Shoes",
            // "brand": "Nike",
            // "price": 109.99
            // }
        }
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating) {

            var item = _db.Items.Find(id);
            if (item == null) 
            {
                return NotFound();
            }

            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }
        [HttpPut("id:int")]
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
            if (id != item.Id) 
            {
                return BadRequest();
            }

            if (_db.Items.Find(id) == null) 
            {
                return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }

        // public IActionResult Put(int id, Item item) {
        //     return NoContent();
        // }
        // [HttpDelete("id:int")]
        // public IActionResult Delete(int id) {
        //     return NoContent();
        // }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if(item == null)
            {
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }
        
    }
    
    
}