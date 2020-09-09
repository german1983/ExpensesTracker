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
    public class UserInstitutionsController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public UserInstitutionsController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInstitutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInstitution>>> GetUserInstitutions()
        {
            return await _context.UserInstitutions.ToListAsync();
        }

        // GET: api/UserInstitutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInstitution>> GetUserInstitution(Guid id)
        {
            var userInstitution = await _context.UserInstitutions.FindAsync(id);

            if (userInstitution == null)
            {
                return NotFound();
            }

            return userInstitution;
        }

        // PUT: api/UserInstitutions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInstitution(Guid id, UserInstitution userInstitution)
        {
            if (id != userInstitution.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInstitution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInstitutionExists(id))
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

        // POST: api/UserInstitutions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserInstitution>> PostUserInstitution(UserInstitution userInstitution)
        {
            _context.UserInstitutions.Add(userInstitution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInstitution", new { id = userInstitution.Id }, userInstitution);
        }

        // DELETE: api/UserInstitutions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInstitution>> DeleteUserInstitution(Guid id)
        {
            var userInstitution = await _context.UserInstitutions.FindAsync(id);
            if (userInstitution == null)
            {
                return NotFound();
            }

            _context.UserInstitutions.Remove(userInstitution);
            await _context.SaveChangesAsync();

            return userInstitution;
        }

        private bool UserInstitutionExists(Guid id)
        {
            return _context.UserInstitutions.Any(e => e.Id == id);
        }
    }
}
