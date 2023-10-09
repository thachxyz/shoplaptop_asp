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
    public class MessageController : ControllerBase
    {
        public readonly Example07Context _context;
        public MessageController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/messagess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            if (_context.Messages == null)
            {
                return NotFound();

            }
            return await _context.Messages.ToListAsync();
        }
        // GET api/<MessagesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessages(long id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var messages = await _context.Messages.FindAsync(id);
            if (messages == null)
            {
                return NotFound();
            }
            return messages;

        }
        // Put api/Messages/5
        [HttpPut]
        public async Task<IActionResult> PutMessage(long id, Message messages)
        {
            if (id != messages.Id)
            {
                return BadRequest();
            }
            _context.Entry(messages).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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
        // POSt api/Messages
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message messages)
        {
            if (_context.Messages == null)
            {
                return Problem("Entity  set'Example07.Messages' is null.");
            }
            _context.Messages.Add(messages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessages", new { id = messages.Id}, messages);
        }
        // DELETE api/<MessagesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(long id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var messages = await _context.Messages.FindAsync(id);
            if(messages == null)
            {
                return NotFound();
            }
            _context.Messages.Remove(messages);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool MessageExists (long id)
        {
            return (_context.Messages?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
        
    }
}