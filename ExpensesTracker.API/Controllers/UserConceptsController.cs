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
    public class UserConceptsController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public UserConceptsController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/UserConcepts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserConcept>>> GetUserConcepts()
        {
            return await _context.UserConcepts.ToListAsync();
        }

        // GET: api/UserConcepts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserConcept>> GetUserConcept(Guid id)
        {
            var userConcept = await _context.UserConcepts.FindAsync(id);

            if (userConcept == null)
            {
                return NotFound();
            }

            return userConcept;
        }

        // PUT: api/UserConcepts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserConcept(Guid id, UserConcept userConcept)
        {
            if (id != userConcept.Id)
            {
                return BadRequest();
            }

            _context.Entry(userConcept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserConceptExists(id))
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

        // POST: api/UserConcepts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserConcept>> PostUserConcept(UserConcept userConcept)
        {
            _context.UserConcepts.Add(userConcept);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserConcept", new { id = userConcept.Id }, userConcept);
        }

        // DELETE: api/UserConcepts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserConcept>> DeleteUserConcept(Guid id)
        {
            var userConcept = await _context.UserConcepts.FindAsync(id);
            if (userConcept == null)
            {
                return NotFound();
            }

            _context.UserConcepts.Remove(userConcept);
            await _context.SaveChangesAsync();

            return userConcept;
        }

        private bool UserConceptExists(Guid id)
        {
            return _context.UserConcepts.Any(e => e.Id == id);
        }
    }
}
