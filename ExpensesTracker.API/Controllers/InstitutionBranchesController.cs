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
    public class InstitutionBranchesController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public InstitutionBranchesController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/InstitutionBranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitutionBranch>>> GetInstitutionBranches()
        {
            return await _context.InstitutionBranches.ToListAsync();
        }

        // GET: api/InstitutionBranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstitutionBranch>> GetInstitutionBranch(Guid id)
        {
            var institutionBranch = await _context.InstitutionBranches.FindAsync(id);

            if (institutionBranch == null)
            {
                return NotFound();
            }

            return institutionBranch;
        }

        // PUT: api/InstitutionBranches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitutionBranch(Guid id, InstitutionBranch institutionBranch)
        {
            if (id != institutionBranch.Id)
            {
                return BadRequest();
            }

            _context.Entry(institutionBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionBranchExists(id))
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

        // POST: api/InstitutionBranches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InstitutionBranch>> PostInstitutionBranch(InstitutionBranch institutionBranch)
        {
            _context.InstitutionBranches.Add(institutionBranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitutionBranch", new { id = institutionBranch.Id }, institutionBranch);
        }

        // DELETE: api/InstitutionBranches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstitutionBranch>> DeleteInstitutionBranch(Guid id)
        {
            var institutionBranch = await _context.InstitutionBranches.FindAsync(id);
            if (institutionBranch == null)
            {
                return NotFound();
            }

            _context.InstitutionBranches.Remove(institutionBranch);
            await _context.SaveChangesAsync();

            return institutionBranch;
        }

        private bool InstitutionBranchExists(Guid id)
        {
            return _context.InstitutionBranches.Any(e => e.Id == id);
        }
    }
}
