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
    public class UsersController : ControllerBase {

        private readonly CareerDbContext _context;

        public UsersController(CareerDbContext context) {
            _context = context;
            var userTableEmpty = _context.Users.Count() == 0;
            if(userTableEmpty) { // no users
                Init();
            }
        }

        private void Init() {
            var greg = new User { Email = "gdoud@maxtrain.com",
                Password = "sha256-b4e8745eec8d4065da7d4c91ea6e0891a96fcffda83c938ca45b89e31cc333ec",
                Lastname = "Doud", Firstname = "Greg",
                Phone = "513-703-7315", Admin = true,
                Created = DateTime.Now
            };
            var annette = new User {
                Email = "aballard@maxtrain.com",
                Password = "sha256-bd3023c9f85656458be657c447a5bce9fd970001a8023a9b55dd2281910d1546",
                Lastname = "Ballard", Firstname = "Annette",
                Phone = "513-374-0382", Admin = true,
                Created = DateTime.Now
            };
            _context.Users.Add(greg);
            _context.Users.Add(annette);
            _context.SaveChanges();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
            if (_context.Users == null) {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id) {
            if (_context.Users == null) {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null) {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/x@x.x/x
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> GetUserByEmailAndPassword(string email, string password) {
            if (_context.Users == null) {
                return NotFound();
            }

            User? user = null;
            try {
                user = await _context.Users
                                    .SingleOrDefaultAsync(x => x.Email == email && x.Active);
                if (user == null || user.Password != password) {
                    return NotFound();
                }
                return user;
            } catch (Exception ex) {
                var x = 0;
            }

            return NotFound();
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user) {
            if (id != user.Id) {
                return BadRequest();
            }

            user.Updated = DateTime.Now;
            _context.Entry(user).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!UserExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user) {
            if (_context.Users == null) {
                return Problem("Entity set 'CareerDbContext.Users'  is null.");
            }
            user.Created = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) {
            if (_context.Users == null) {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null) {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id) {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
