using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly Example07Context _context;
        public DealController(Example07Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Deal>> GetHotDeal()
        {
            if(_context.Deals == null)
            {
                return NotFound();
            }
            var now = DateTime.Now.Date;
            return _context.Deals.Where(x=>x.Starts <= now && x.Ends >= now).First();

        }
    }
}