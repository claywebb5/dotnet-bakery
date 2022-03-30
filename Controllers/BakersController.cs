using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BakersController(ApplicationContext context)
        {
            _context = context; // This is our: pool
        }

        // OUR API
        // ============<GET - All bakers>=============
        [HttpGet]
        // IEnumerable is a "fancy List"
        public IEnumerable<Baker> GetAll()
        {
            Console.WriteLine("Get all bakers");
            // No SQL! Return all the rows in the Bakers table
            return _context.Bakers;
        }

        // ============<GET - a single baker by id>=============
        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id)
        {
            Baker baker = _context.Bakers
                .SingleOrDefault(baker => baker.id == id);

            // Return a 404 Not Found if the baker doesn't exist
            if (baker is null)
            {
                return NotFound();
            }

            return baker;
        }

        // ============<POST - add a new baker>=============
        // Note that .NET parses our JSON request body for us
        // and converts it to a `Baker` model object.
        [HttpPost]
        public IActionResult Post(Baker baker)
        {
            // Uses a transaction
            _context.Add(baker); // Insert into table, not committed
            _context.SaveChanges(); // Commits to the database

            // return baker; <- This would be missing id

            // This will add the id of the new baker, 
            // and send the new baker object 
            // Returns the url to /api/Bakers?id=<new-id-number>
            return CreatedAtAction(nameof(Post),
                            new { id = baker.id }, baker);
        }
        // ============<DELETE - a single baker by id>=============

        // ============<PUT - change a single bakers name by id>=============

        // ============<STRETCH: PATCH - a single baker by id>=============
    }
}
