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
    public class CompanyMastersController : ControllerBase {
        private readonly CareerDbContext _context;

        public CompanyMastersController(CareerDbContext context) {
            _context = context;
        }

        // GET: api/CompanyMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyMaster>>> GetCompanyMasters() {
            if (_context.CompanyMasters == null) {
                return NotFound();
            }
            return await _context.CompanyMasters.ToListAsync();
        }

        // GET: api/CompanyMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyMaster>> GetCompanyMaster(int id) {
            if (_context.CompanyMasters == null) {
                return NotFound();
            }
            var companyMaster = await _context.CompanyMasters.FindAsync(id);

            if (companyMaster == null) {
                return NotFound();
            }

            return companyMaster;
        }

        // PUT: api/CompanyMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyMaster(int id, CompanyMaster companyMaster) {
            if (id != companyMaster.Id) {
                return BadRequest();
            }

            _context.Entry(companyMaster).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CompanyMasterExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CompanyMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyMaster>> PostCompanyMaster(CompanyMaster companyMaster) {
            if (_context.CompanyMasters == null) {
                return Problem("Entity set 'CareerDbContext.CompanyMasters'  is null.");
            }
            _context.CompanyMasters.Add(companyMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyMaster", new { id = companyMaster.Id }, companyMaster);
        }

        // DELETE: api/CompanyMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyMaster(int id) {
            if (_context.CompanyMasters == null) {
                return NotFound();
            }
            var companyMaster = await _context.CompanyMasters.FindAsync(id);
            if (companyMaster == null) {
                return NotFound();
            }

            _context.CompanyMasters.Remove(companyMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyMasterExists(int id) {
            return (_context.CompanyMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
