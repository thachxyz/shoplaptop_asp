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
    public class OrderController : ControllerBase
    {
        public readonly Example07Context _context;
        public OrderController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/settings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();

            }
            return await _context.Orders.ToListAsync();
        }
        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrders(long id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return orders;

        }
        // Put api/Orders/5
        [HttpPut]
        public async Task<IActionResult> PutOrder(long id, Order orders)
        {
            if (id != orders.Id)
            {
                return BadRequest();
            }
            _context.Entry(orders).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        // POSt api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order orders)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity  set'Example07.Order' is null.");
            }
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = orders.Id}, orders);
        }
        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var setting = await _context.Orders.FindAsync(id);
            if(setting == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(setting);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool OrderExists (long id)
        {
            return (_context.Orders?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
        
    }
}