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
    public class CompanyConnectionsController : ControllerBase {
        private readonly CareerDbContext _context;

        public CompanyConnectionsController(CareerDbContext context) {
            _context = context;
        }

        // GET: api/CompanyConnections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyConnection>>> GetCompanyConnections() {
            if (_context.CompanyConnections == null) {
                return NotFound();
            }
            return await _context.CompanyConnections.ToListAsync();
        }

        // GET: api/CompanyConnections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyConnection>> GetCompanyConnection(int id) {
            if (_context.CompanyConnections == null) {
                return NotFound();
            }
            var companyConnection = await _context.CompanyConnections.FindAsync(id);

            if (companyConnection == null) {
                return NotFound();
            }

            return companyConnection;
        }

        // PUT: api/CompanyConnections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyConnection(int id, CompanyConnection companyConnection) {
            if (id != companyConnection.Id) {
                return BadRequest();
            }

            _context.Entry(companyConnection).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CompanyConnectionExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CompanyConnections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyConnection>> PostCompanyConnection(CompanyConnection companyConnection) {
            if (_context.CompanyConnections == null) {
                return Problem("Entity set 'CareerDbContext.CompanyConnections'  is null.");
            }
            _context.CompanyConnections.Add(companyConnection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyConnection", new { id = companyConnection.Id }, companyConnection);
        }

        // DELETE: api/CompanyConnections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyConnection(int id) {
            if (_context.CompanyConnections == null) {
                return NotFound();
            }
            var companyConnection = await _context.CompanyConnections.FindAsync(id);
            if (companyConnection == null) {
                return NotFound();
            }

            _context.CompanyConnections.Remove(companyConnection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyConnectionExists(int id) {
            return (_context.CompanyConnections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
