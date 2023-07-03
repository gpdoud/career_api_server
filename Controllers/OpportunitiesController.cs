using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using career_api_server.Models;

namespace career_api_server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunitiesController : ControllerBase {
        private readonly CareerDbContext _context;

        public OpportunitiesController(CareerDbContext context) {
            _context = context;
        }

        // GET: api/Opportunities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opportunity>>> GetOpportunities() {
            if (_context.Opportunities == null) {
                return NotFound();
            }
            return await _context.Opportunities
                                    .Include(x => x.User)
                                    .Include(x => x.Company)
                                    .Include(x => x.CompanyConnection)
                                    .ToListAsync();
        }

        // GET: api/Opportunities
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Opportunity>>> GetOpportunitiesForStudent(int id) {
            if (_context.Opportunities == null) {
                return NotFound();
            }
            return await _context.Opportunities
                                    .Include(x => x.User)
                                    .Include(x => x.Company)
                                    .Include(x => x.CompanyConnection)
                                    .Include(x => x.Activities)
                                        .ThenInclude(x => x.ActivityType)
                                    .Where(x => x.UserId == id)
                                    .ToListAsync();
        }


        // GET: api/Opportunities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Opportunity>> GetOpportunity(int id) {
            if (_context.Opportunities == null) {
                return NotFound();
            }
            var opportunity = await _context.Opportunities
                                                .Include(x => x.User)
                                                .Include(x => x.Company)
                                                .Include(x => x.CompanyConnection)
                                                .Include(x => x.Activities)
                                                    .ThenInclude(x => x.ActivityType)
                                                .SingleOrDefaultAsync(x => x.Id == id);

            if (opportunity == null) {
                return NotFound();
            }

            return opportunity;
        }

        // PUT: api/Opportunities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpportunity(int id, Opportunity opportunity) {
            if (id != opportunity.Id) {
                return BadRequest();
            }

            _context.Entry(opportunity).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!OpportunityExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Opportunities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Opportunity>> PostOpportunity(Opportunity opportunity) {
            if (_context.Opportunities == null) {
                return Problem("Entity set 'CareerDbContext.Opportunities'  is null.");
            }
            _context.Opportunities.Add(opportunity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpportunity", new { id = opportunity.Id }, opportunity);
        }

        // DELETE: api/Opportunities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpportunity(int id) {
            if (_context.Opportunities == null) {
                return NotFound();
            }
            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null) {
                return NotFound();
            }

            _context.Opportunities.Remove(opportunity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpportunityExists(int id) {
            return (_context.Opportunities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
