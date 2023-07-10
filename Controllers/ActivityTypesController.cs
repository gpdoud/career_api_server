﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using career_api_server.Models;
using System.Runtime.CompilerServices;

namespace career_api_server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypesController : ControllerBase {
        private readonly CareerDbContext _context;

        public ActivityTypesController(CareerDbContext context) {
            _context = context;
        }

        // GET: api/ActivityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityType>>> GetActivityTypes() {
            if (_context.ActivityTypes == null) {
                return NotFound();
            }
            return await _context.ActivityTypes.ToListAsync();
        }

        // GET: api/ActivityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityType>> GetActivityType(int id) {
            if (_context.ActivityTypes == null) {
                return NotFound();
            }
            var activityType = await _context.ActivityTypes.FindAsync(id);

            if (activityType == null) {
                return NotFound();
            }

            return activityType;
        }

        // PUT: api/ActivityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityType(int id, ActivityType activityType) {
            if (id != activityType.Id) {
                return BadRequest();
            }

            _context.Entry(activityType).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ActivityTypeExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActivityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityType>> PostActivityType(ActivityType activityType) {
            if (_context.ActivityTypes == null) {
                return Problem("Entity set 'CareerDbContext.ActivityTypes'  is null.");
            }
            _context.ActivityTypes.Add(activityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityType", new { id = activityType.Id }, activityType);
        }

        // DELETE: api/ActivityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityType(int id) {
            if (_context.ActivityTypes == null) {
                return NotFound();
            }
            var activityType = await _context.ActivityTypes.FindAsync(id);
            if (activityType == null) {
                return NotFound();
            }

            _context.ActivityTypes.Remove(activityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityTypeExists(int id) {
            return (_context.ActivityTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
