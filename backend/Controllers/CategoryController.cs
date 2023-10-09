using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend;
using backend.Models;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace Example07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Example07Context _context;

        public CategoryController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            if (_context.GetCategories == null)
            {
                return NotFound();
            }
            return await _context.GetCategories.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            if (_context.GetCategories == null)
            {
                return NotFound();
            }
            var category = await _context.GetCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (_context.GetCategories == null)
            {
                return Problem("Entity set 'Example07Context.Category' is null.");
            }
            _context.GetCategories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            if (_context.GetCategories == null)
            {
                return NotFound();
            }
            var category = await _context.GetCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.GetCategories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CategoryExists(long id)
        {
            return (_context.GetCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}