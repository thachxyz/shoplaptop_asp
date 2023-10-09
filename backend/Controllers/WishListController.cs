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
    public class WishListController : ControllerBase
    {
        private readonly Example07Context _context;

        public WishListController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishList>>> GetWishLists()
        {
            if (_context.WishLists == null)
            {
                return NotFound();
            }
            return await _context.WishLists.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WishList>> GetWishLists(long id)
        {
            if (_context.WishLists == null)
            {
                return NotFound();
            }
            var wishList = await _context.WishLists.FindAsync(id);
            if (wishList == null)
            {
                return NotFound();
            }
            return wishList;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishLists(long id, WishList wishList)
        {
            if (id != wishList.Id)
            {
                return BadRequest();
            }
            _context.Entry(wishList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishListsExists(id))
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
        public async Task<ActionResult<WishList>> PostWishLists(WishList wishList)
        {
            if (_context.WishLists == null)
            {
                return Problem("Entity set 'Example07Context.WishList' is null.");
            }
            _context.WishLists.Add(wishList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishLists", new { id = wishList.Id }, wishList);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishLists(long id)
        {
            if (_context.WishLists == null)
            {
                return NotFound();
            }
            var wishList = await _context.WishLists.FindAsync(id);
            if (wishList == null)
            {
                return NotFound();
            }
            _context.WishLists.Remove(wishList);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool WishListsExists(long id)
        {
            return (_context.WishLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}