using AliBazar.Application.Services.CommentServices;
using AliBazar.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommnetService _commentService;

        public CommentController(ICommnetService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(CommentDTO commentDTO)
        {
            var result = await _commentService.CreateComment(commentDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentService.GetAllComments();
            return Ok(result);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetCommentsByProductId(long id)
        {
            var result = await _commentService.GetCommentsByProductId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetCommentsByUserId(long id)
        {
            var result = await _commentService.GetCommentsByUserId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(long id)
        {
            var result = await _commentService.DeleteCommentById(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
