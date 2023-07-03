﻿using System;
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
    public class ActivitiesController : ControllerBase {
        private readonly CareerDbContext _context;

        public ActivitiesController(CareerDbContext context) {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities() {
            if (_context.Activities == null) {
                return NotFound();
            }
            return await _context.Activities
                                    .Include(x => x.ActivityType)
                                    .ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id) {
            if (_context.Activities == null) {
                return NotFound();
            }
            var activity = await _context.Activities
                                            .Include(x => x.ActivityType)    
                                            .SingleOrDefaultAsync(x => x.Id == id);

            if (activity == null) {
                return NotFound();
            }

            return activity;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(int id, Activity activity) {
            if (id != activity.Id) {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ActivityExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity) {
            if (_context.Activities == null) {
                return Problem("Entity set 'CareerDbContext.Activities'  is null.");
            }
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivity", new { id = activity.Id }, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id) {
            if (_context.Activities == null) {
                return NotFound();
            }
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) {
                return NotFound();
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityExists(int id) {
            return (_context.Activities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
