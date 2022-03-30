using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context)
        {
            _context = context;
        }

        // OUR API
        // ============<GET - All breads>=============
        // Note that `IEnumerable<Bread>` is C#'s fancy way 
        // of saying "a list of Baker objects"
        [HttpGet]
        public IEnumerable<Bread> GetBreads()
        {
            return _context.Breads
                // Include the `bakedBy` property
                // which is a list of `Baker` objects
                // .NET will do a JOIN for us!
                .Include(bread => bread.bakedBy);
        }

        // ============<GET - a single bread by id>=============
        [HttpGet("{id}")]
        public ActionResult<Bread> GetById(int id)
        {
            Bread bread = _context.Breads
                .SingleOrDefault(bread => bread.id == id);

            // Return a 404 Not Found if the baker doesn't exist
            if (bread is null)
            {
                return NotFound();
            }

            return bread;
        }

        // ============<POST>=============
        // .NET automatically converts our JSON request body
        // into a `Bread` object. 
        [HttpPost]
        public IActionResult Create(Bread bread)
        {
            // Tell the DB context about our new bread object
            _context.Add(bread);
            // ...and save the bread object to the database
            _context.SaveChanges();

            // Respond back with the created bread object
            return CreatedAtAction(nameof(Create), new {id = bread.id}, bread);
        }

        // ============<DELETE>=============
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Find the bread, by ID
            Bread bread = _context.Breads.SingleOrDefault(b => b.id == id);
            // If the bread is not found return the error
            if(bread is null) {
                return NotFound();
            }

            // Tell the DB that we want to remove this bread
            _context.Breads.Remove(bread);

            // Save the changes to the database
            _context.SaveChanges();

            // 204 message
            return NoContent();
        }


        // ============<PUT>=============
        // Updates a bread by id
        // Returns NoContent()
        // Bread must contain all fields that are NOT NULL
        // Nullables will be filled with NULL if they are missing from the
        [HttpPut("{id}")]
        public IActionResult Put(int id, Bread bread)
        {
            Console.WriteLine("In PUT");
            // If the id on the url does not match the id of the bread
            // send a BadRequest error
            if(id != bread.id) {
                return BadRequest();
            }

            // Tell the DB context about our updated bread object
            _context.Update(bread);

            // Save the bread object to the database
            _context.SaveChanges();

            // 
            return NoContent();
        }

        // ============<STRETCH: PATCH>=============

    }
}
