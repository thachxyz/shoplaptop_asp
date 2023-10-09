using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    
    {

        private readonly Example07Context _context;

        public BannerController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banner>>> GetBanner()
        {
            if (_context.Banners == null)
            {
                return NotFound();
            }
            return await _context.Banners.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banner>> GetBanners(long id)
        {
            if (_context.Banners == null)
            {
                return NotFound();
            }
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return banner;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanner(long id, Banner banner)
        {
            if (id != banner.Id)
            {
                return BadRequest();
            }
            _context.Entry(banner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(id))
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
        public async Task<ActionResult<Banner>> PostBanner(Banner banner)
        {
            if (_context.Banners == null)
            {
                return Problem("Entity set 'Example07Context.Banner' is null.");
            }
            _context.Banners.Add(banner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanners", new { id = banner.Id }, banner);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(long id)
        {
            if (_context.Banners == null)
            {
                return NotFound();
            }
            var category = await _context.Banners.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Banners.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool BannerExists(long id)
        {
            return (_context.Banners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}