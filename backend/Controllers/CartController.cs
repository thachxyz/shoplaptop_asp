using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
         public readonly Example07Context _context;
        public CartController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            if (_context.Carts == null)
            {
                return NotFound();

            }
            return await _context.Carts.ToListAsync();
        }
        // GET api/<CartsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCarts(long id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return cart;

        }
        // Put api/Carts/5
        [HttpPut]
        public async Task<IActionResult> PutCart(long id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }
            _context.Entry(cart).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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
        // POSt api/Carts
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity  set'Example07.Cart' is null.");
            }
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarts", new { id = cart.Id}, cart);
        }
        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(long id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var cart = await _context.Carts.FindAsync(id);
            if(cart == null)
            {
                return NotFound();
            }
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CartExists (long id)
        {
            return (_context.Carts?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
    }
}