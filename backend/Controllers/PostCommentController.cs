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
    public class PostCommentController : ControllerBase
    { public readonly Example07Context _context;
        public PostCommentController(Example07Context context)
        {
            _context = context;
        }
        // GET: api/postComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostComment>>> GetPostComments()
        {
            if (_context.PostComments == null)
            {
                return NotFound();

            }
            return await _context.PostComments.ToListAsync();
        }
        // GET api/<PostCommentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostComment>> GetPostComments(long id)
        {
            if (_context.PostComments == null)
            {
                return NotFound();
            }
            var postComment = await _context.PostComments.FindAsync(id);
            if (postComment == null)
            {
                return NotFound();
            }
            return postComment;

        }
        // Put api/PostComments/5
        [HttpPut]
        public async Task<IActionResult> PutPostComment(long id, PostComment postComment)
        {
            if (id != postComment.Id)
            {
                return BadRequest();
            }
            _context.Entry(postComment).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCommentExists(id))
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
        // POSt api/PostComments
        [HttpPost]
        public async Task<ActionResult<PostComment>> PostPostComment(PostComment postComment)
        {
            if (_context.PostComments == null)
            {
                return Problem("Entity  set'Example07.PostComment' is null.");
            }
            _context.PostComments.Add(postComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostComments", new { id = postComment.Id}, postComment);
        }
        // DELETE api/<PostCommentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostComment(long id)
        {
            if (_context.PostComments == null)
            {
                return NotFound();
            }
            var postComment = await _context.PostComments.FindAsync(id);
            if(postComment == null)
            {
                return NotFound();
            }
            _context.PostComments.Remove(postComment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PostCommentExists (long id)
        {
            return (_context.PostComments?.Any(e=>e.Id==id)).GetValueOrDefault();
        }
        
    }
}