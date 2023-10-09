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
    public class SettingController : ControllerBase
    {
        public readonly Example07Context _context;
        public SettingController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/settings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setting>>> GetSettings()
        {
            if (_context.Settings == null)
            {
                return NotFound();

            }
            return await _context.Settings.ToListAsync();
        }
        // GET api/<SettingsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Setting>> GetSettings(long id)
        {
            if (_context.Settings == null)
            {
                return NotFound();
            }
            var setting = await _context.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }
            return setting;

        }
        // Put api/Settings/5
        [HttpPut]
        public async Task<IActionResult> PutSetting(long id, Setting setting)
        {
            if (id != setting.Id)
            {
                return BadRequest();
            }
            _context.Entry(setting).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingExists(id))
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
        // POSt api/Settings
        [HttpPost]
        public async Task<ActionResult<Setting>> PostSetting(Setting setting)
        {
            if (_context.Settings == null)
            {
                return Problem("Entity  set'Example07.Setting' is null.");
            }
            _context.Settings.Add(setting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSettings", new { id = setting.Id}, setting);
        }
        // DELETE api/<SettingsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetting(long id)
        {
            if (_context.Settings == null)
            {
                return NotFound();
            }
            var setting = await _context.Settings.FindAsync(id);
            if(setting == null)
            {
                return NotFound();
            }
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool SettingExists (long id)
        {
            return (_context.Settings?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
    }
}