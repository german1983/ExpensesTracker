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
    public class UserInstitutionBranchesController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public UserInstitutionBranchesController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInstitutionBranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInstitutionBranch>>> GetUserInstitutionBranches()
        {
            return await _context.UserInstitutionBranches.ToListAsync();
        }

        // GET: api/UserInstitutionBranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInstitutionBranch>> GetUserInstitutionBranch(Guid id)
        {
            var userInstitutionBranch = await _context.UserInstitutionBranches.FindAsync(id);

            if (userInstitutionBranch == null)
            {
                return NotFound();
            }

            return userInstitutionBranch;
        }

        // PUT: api/UserInstitutionBranches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInstitutionBranch(Guid id, UserInstitutionBranch userInstitutionBranch)
        {
            if (id != userInstitutionBranch.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInstitutionBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInstitutionBranchExists(id))
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

        // POST: api/UserInstitutionBranches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserInstitutionBranch>> PostUserInstitutionBranch(UserInstitutionBranch userInstitutionBranch)
        {
            _context.UserInstitutionBranches.Add(userInstitutionBranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInstitutionBranch", new { id = userInstitutionBranch.Id }, userInstitutionBranch);
        }

        // DELETE: api/UserInstitutionBranches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInstitutionBranch>> DeleteUserInstitutionBranch(Guid id)
        {
            var userInstitutionBranch = await _context.UserInstitutionBranches.FindAsync(id);
            if (userInstitutionBranch == null)
            {
                return NotFound();
            }

            _context.UserInstitutionBranches.Remove(userInstitutionBranch);
            await _context.SaveChangesAsync();

            return userInstitutionBranch;
        }

        private bool UserInstitutionBranchExists(Guid id)
        {
            return _context.UserInstitutionBranches.Any(e => e.Id == id);
        }
    }
}
