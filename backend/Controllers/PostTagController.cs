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
    public class PostTagController : ControllerBase
    {
         public readonly Example07Context _context;
        public PostTagController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/postTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostTag>>> GetPostTags()
        {
            if (_context.PostTags == null)
            {
                return NotFound();

            }
            return await _context.PostTags.ToListAsync();
        }
        // GET api/<PostTagsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostTag>> GetPostTags(long id)
        {
            if (_context.PostTags == null)
            {
                return NotFound();
            }
            var postTag = await _context.PostTags.FindAsync(id);
            if (postTag == null)
            {
                return NotFound();
            }
            return postTag;

        }
        // Put api/PostTags/5
        [HttpPut]
        public async Task<IActionResult> PutPostTag(long id, PostTag postTag)
        {
            if (id != postTag.Id)
            {
                return BadRequest();
            }
            _context.Entry(postTag).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTagExists(id))
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
        // POSt api/PostTags
        [HttpPost]
        public async Task<ActionResult<PostTag>> PostPostTag(PostTag postTag)
        {
            if (_context.PostTags == null)
            {
                return Problem("Entity  set'Example07.PostTag' is null.");
            }
            _context.PostTags.Add(postTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostTags", new { id = postTag.Id}, postTag);
        }
        // DELETE api/<PostTagsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostTag(long id)
        {
            if (_context.PostTags == null)
            {
                return NotFound();
            }
            var postTag = await _context.PostTags.FindAsync(id);
            if(postTag == null)
            {
                return NotFound();
            }
            _context.PostTags.Remove(postTag);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PostTagExists (long id)
        {
            return (_context.PostTags?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
    }
}