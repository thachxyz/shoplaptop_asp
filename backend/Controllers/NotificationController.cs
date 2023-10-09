using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
         
        private readonly Example07Context _context;

        public NotificationController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications()
        {
            if (_context.Notifications == null)
            {
                return NotFound();
            }
            return await _context.Notifications.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotifications(long id)
        {
            if (_context.Notifications == null)
            {
                return NotFound();
            }
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return notification;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotifications(string id, Notification notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }
            _context.Entry(notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationsExists(id))
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

        //PUT: api/Products
        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotifications(Notification notification)
        {
            if (_context.Notifications == null)
            {
                return Problem("Entity set 'Example07Context.Notifications' is null.");
            }
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotifications", new { id = notification.Id }, notification);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifications(string id)
        {
            if (_context.Notifications == null)
            {
                return NotFound();
            }
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool NotificationsExists(string id)
        {
            return (_context.Notifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}