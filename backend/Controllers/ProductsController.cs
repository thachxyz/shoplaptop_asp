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
    public class ProductsController : ControllerBase
    {
        public readonly Example07Context _context;
        public ProductsController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();

            }
            return await _context.Products.ToListAsync();
        }
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(long id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;

        }
        // Put api/Products/5
        [HttpPut]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        // POSt api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity  set'Example07.Products' is null.");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = product.Id}, product);
        }
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ProductExists (long id)
        {
            return (_context.Products?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
    }
}



