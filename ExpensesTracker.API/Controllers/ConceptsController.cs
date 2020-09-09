using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpensesTracker.API.Data;
using ExpensesTracker.API.Data.Models;

namespace ExpensesTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptsController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public ConceptsController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/Concepts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concept>>> GetConcepts()
        {
            return await _context.Concepts.ToListAsync();
        }

        // GET: api/Concepts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concept>> GetConcept(Guid id)
        {
            var concept = await _context.Concepts.FindAsync(id);

            if (concept == null)
            {
                return NotFound();
            }

            return concept;
        }

        // PUT: api/Concepts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcept(Guid id, Concept concept)
        {
            if (id != concept.Id)
            {
                return BadRequest();
            }

            _context.Entry(concept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConceptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Concepts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Concept>> PostConcept(Concept concept)
        {
            _context.Concepts.Add(concept);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcept", new { id = concept.Id }, concept);
        }

        // DELETE: api/Concepts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Concept>> DeleteConcept(Guid id)
        {
            var concept = await _context.Concepts.FindAsync(id);
            if (concept == null)
            {
                return NotFound();
            }

            _context.Concepts.Remove(concept);
            await _context.SaveChangesAsync();

            return concept;
        }

        private bool ConceptExists(Guid id)
        {
            return _context.Concepts.Any(e => e.Id == id);
        }
    }
}
