using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostCategoryController : ControllerBase
    {
        public readonly Example07Context _context;
        public PostCategoryController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostCategory>>> GetPosts()
        {
            if (_context.PostCategories == null)
            {
                return NotFound();

            }
            return await _context.PostCategories.ToListAsync();
        }
        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostCategory>> GetPosts(long id)
        {
            if (_context.PostCategories == null)
            {
                return NotFound();
            }
            var postCategories = await _context.PostCategories.FindAsync(id);
            if (postCategories == null)
            {
                return NotFound();
            }
            return postCategories;

        }
        // Put api/PostCategories/5
        [HttpPut]
        public async Task<IActionResult> PutPost(long id, PostCategory postCategories)
        {
            if (id != postCategories.Id)
            {
                return BadRequest();
            }
            _context.Entry(postCategories).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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
        // POSt api/PostCategories
        [HttpPost]
        public async Task<ActionResult<PostCategory>> PostPost(PostCategory postCategories)
        {
            if (_context.PostCategories == null)
            {
                return Problem("Entity  set'Example07.PostCategory' is null.");
            }
            _context.PostCategories.Add(postCategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = postCategories.Id}, postCategories);
        }
        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            if (_context.PostCategories == null)
            {
                return NotFound();
            }
            var postCategories = await _context.PostCategories.FindAsync(id);
            if(postCategories == null)
            {
                return NotFound();
            }
            _context.PostCategories.Remove(postCategories);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PostExists (long id)
        {
            return (_context.PostCategories?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
    }
}