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
    public class CouponController : ControllerBase
    {
        
        private readonly Example07Context _context;

        public CouponController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetCoupon()
        {
            if (_context.Coupons == null)
            {
                return NotFound();
            }
            return await _context.Coupons.ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coupon>> GetCoupons(long id)
        {
            if (_context.Coupons == null)
            {
                return NotFound();
            }
            var category = await _context.Coupons.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoupon(long id, Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return BadRequest();
            }
            _context.Entry(coupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
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
        public async Task<ActionResult<Coupon>> PostCoupon(Coupon coupon)
        {
            if (_context.Coupons == null)
            {
                return Problem("Entity set 'Example07Context.Coupon' is null.");
            }
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoupons", new { id = coupon.Id }, coupon);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(long id)
        {
            if (_context.Coupons == null)
            {
                return NotFound();
            }
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CouponExists(long id)
        {
            return (_context.Coupons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}