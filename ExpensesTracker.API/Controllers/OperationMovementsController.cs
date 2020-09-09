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
    public class OperationMovementsController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public OperationMovementsController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/OperationMovements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationMovement>>> GetOperationMovements()
        {
            return await _context.OperationMovements.ToListAsync();
        }

        // GET: api/OperationMovements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationMovement>> GetOperationMovement(Guid id)
        {
            var operationMovement = await _context.OperationMovements.FindAsync(id);

            if (operationMovement == null)
            {
                return NotFound();
            }

            return operationMovement;
        }

        // PUT: api/OperationMovements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationMovement(Guid id, OperationMovement operationMovement)
        {
            if (id != operationMovement.Id)
            {
                return BadRequest();
            }

            _context.Entry(operationMovement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationMovementExists(id))
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

        // POST: api/OperationMovements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OperationMovement>> PostOperationMovement(OperationMovement operationMovement)
        {
            _context.OperationMovements.Add(operationMovement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperationMovement", new { id = operationMovement.Id }, operationMovement);
        }

        // DELETE: api/OperationMovements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationMovement>> DeleteOperationMovement(Guid id)
        {
            var operationMovement = await _context.OperationMovements.FindAsync(id);
            if (operationMovement == null)
            {
                return NotFound();
            }

            _context.OperationMovements.Remove(operationMovement);
            await _context.SaveChangesAsync();

            return operationMovement;
        }

        private bool OperationMovementExists(Guid id)
        {
            return _context.OperationMovements.Any(e => e.Id == id);
        }
    }
}
