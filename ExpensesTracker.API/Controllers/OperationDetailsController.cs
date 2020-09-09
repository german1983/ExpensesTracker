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
    public class OperationDetailsController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public OperationDetailsController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/OperationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDetail>>> GetOperationDetails()
        {
            return await _context.OperationDetails.ToListAsync();
        }

        // GET: api/OperationDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDetail>> GetOperationDetail(Guid id)
        {
            var operationDetail = await _context.OperationDetails.FindAsync(id);

            if (operationDetail == null)
            {
                return NotFound();
            }

            return operationDetail;
        }

        // PUT: api/OperationDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationDetail(Guid id, OperationDetail operationDetail)
        {
            if (id != operationDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(operationDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationDetailExists(id))
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

        // POST: api/OperationDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OperationDetail>> PostOperationDetail(OperationDetail operationDetail)
        {
            _context.OperationDetails.Add(operationDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperationDetail", new { id = operationDetail.Id }, operationDetail);
        }

        // DELETE: api/OperationDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationDetail>> DeleteOperationDetail(Guid id)
        {
            var operationDetail = await _context.OperationDetails.FindAsync(id);
            if (operationDetail == null)
            {
                return NotFound();
            }

            _context.OperationDetails.Remove(operationDetail);
            await _context.SaveChangesAsync();

            return operationDetail;
        }

        private bool OperationDetailExists(Guid id)
        {
            return _context.OperationDetails.Any(e => e.Id == id);
        }
    }
}
