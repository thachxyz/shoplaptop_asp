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
    public class ProductReviewController : ControllerBase
    {
         private readonly Example07Context _context;

        public ProductReviewController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReview>>> GetProductReview()
        {
            if (_context.ProductReviews == null)
            {
                return NotFound();
            }
            return await _context.ProductReviews.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReview>> GetProductReview(long id)
        {
            if (_context.ProductReviews == null)
            {
                return NotFound();
            }
            var ProductReview = await _context.ProductReviews.FindAsync(id);
            if (ProductReview == null)
            {
                return NotFound();
            }
            return ProductReview;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductReview(long id, ProductReview ProductReview)
        {
            if (id != ProductReview.Id)
            {
                return BadRequest();
            }
            _context.Entry(ProductReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductReviewExists(id))
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
        public async Task<ActionResult<ProductReview>> PostProductReview(ProductReview ProductReview)
        {
            if (_context.ProductReviews == null)
            {
                return Problem("Entity set 'Example07Context.ProductReview' is null.");
            }
            _context.ProductReviews.Add(ProductReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductReview", new { id = ProductReview.Id }, ProductReview);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductReview(long id)
        {
            if (_context.ProductReviews == null)
            {
                return NotFound();
            }
            var ProductReview = await _context.ProductReviews.FindAsync(id);
            if (ProductReview == null)
            {
                return NotFound();
            }
            _context.ProductReviews.Remove(ProductReview);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ProductReviewExists(long id)
        {
            return (_context.ProductReviews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}