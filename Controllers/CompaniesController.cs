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
    public class CompaniesController : ControllerBase {
        private readonly CareerDbContext _context;

        public CompaniesController(CareerDbContext context) {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies() {
            if (_context.Companies == null) {
                return NotFound();
            }
            return await _context.Companies
                                    .Include(x => x.User)
                                    .ToListAsync();
        }

        // GET: api/Companies/Student/5
        [HttpGet("student/{userId}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesByStudent(int userId) {
            if (_context.Companies == null) {
                return NotFound();
            }
            return await _context.Companies
                                    .Include(x => x.User)
                                    .Where(x => x.UserId == userId)
                                    .ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id) {
            if (_context.Companies == null) {
                return NotFound();
            }
            var company = await _context.Companies
                                            .Include(x => x.User)
                                            .SingleOrDefaultAsync(x => x.Id == id);

            if (company == null) {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company) {
            if (id != company.Id) {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CompanyExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company) {
            if (_context.Companies == null) {
                return Problem("Entity set 'CareerDbContext.Companies'  is null.");
            }
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // POST: api/Companies/assign
        [HttpPost("assign/{userId}")]
        public async Task<ActionResult<Company>> AssignCompany(int userId, CompanyMaster cm) {
            if (_context.Companies == null) {
                return Problem("Entity set 'CareerDbContext.Companies'  is null.");
            }
            var company = Company.CreateInstance(cm);
            company.Id = 0;
            company.UserId = userId;
            return await PostCompany(company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id) {
            if (_context.Companies == null) {
                return NotFound();
            }
            var company = await _context.Companies.FindAsync(id);
            if (company == null) {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id) {
            return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
