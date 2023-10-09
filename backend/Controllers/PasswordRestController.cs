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
    public class PasswordRestController : ControllerBase
    {
        public readonly Example07Context _context;
        public PasswordRestController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordRest>>> GetPasswordRests()
        {
            if (_context.PasswordRests == null)
            {
                return NotFound();

            }
            return await _context.PasswordRests.ToListAsync();
        }
        // GET api/<PasswordRestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordRest>> GetPasswordRests(long id)
        {
            if (_context.PasswordRests == null)
            {
                return NotFound();
            }
            var passwordRest = await _context.PasswordRests.FindAsync(id);
            if (passwordRest == null)
            {
                return NotFound();
            }
            return passwordRest;

        }
        // Put api/PasswordRests/5
        [HttpPut]
        public async Task<IActionResult> PutPasswordRest(long id, PasswordRest passwordRest)
        {
            if (id != passwordRest.Id)
            {
                return BadRequest();
            }
            _context.Entry(passwordRest).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordRestExists(id))
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
        // POSt api/PasswordRests
        [HttpPost]
        public async Task<ActionResult<PasswordRest>> PostPasswordRest(PasswordRest passwordRest)
        {
            if (_context.PasswordRests == null)
            {
                return Problem("Entity  set'Example07.PasswordRests' is null.");
            }
            _context.PasswordRests.Add(passwordRest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasswordRests", new { id = passwordRest.Id}, passwordRest);
        }
        // DELETE api/<PasswordRestsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasswordRest(long id)
        {
            if (_context.PasswordRests == null)
            {
                return NotFound();
            }
            var product = await _context.PasswordRests.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.PasswordRests.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PasswordRestExists (long id)
        {
            return (_context.PasswordRests?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
        
    }
}