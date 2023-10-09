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
    public class ShippingController : ControllerBase
    {
       
        private readonly Example07Context _context;

        public ShippingController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShippings()
        {
            if (_context.Shippings == null)
            {
                return NotFound();
            }
            return await _context.Shippings.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShippings(long id)
        {
            if (_context.Shippings == null)
            {
                return NotFound();
            }
            var shipping = await _context.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return shipping;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippings(long id, Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return BadRequest();
            }
            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingsExists(id))
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
        public async Task<ActionResult<Shipping>> PostShippings(Shipping shipping)
        {
            if (_context.Shippings == null)
            {
                return Problem("Entity set 'Example07Context.Shipping' is null.");
            }
            _context.Shippings.Add(shipping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippings", new { id = shipping.Id }, shipping);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippings(long id)
        {
            if (_context.Shippings == null)
            {
                return NotFound();
            }
            var shipping = await _context.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }
            _context.Shippings.Remove(shipping);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ShippingsExists(long id)
        {
            return (_context.Shippings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}