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
    public class BrandsController :ControllerBase
    {
        private readonly Example07Context _context;

        public  BrandsController (Example07Context context)
        {
            _context = context;
        }
        // GET: api/brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> Getbrand()
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            return await _context.Brands.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrands(long id)
        {
            if(_context.Brands == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrands(long id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }
            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandsExists(id))
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
        public async Task<ActionResult<Brand>> PostBrands(Brand brand)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'Example07Context.Brand' is null.");
            }
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrands", new { id = brand.Id }, brand);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrands(long id)
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool BrandsExists(long id)
        {
            return (_context.Brands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}