using ApplicationLib.DTOs.Comment;
using ApplicationLib.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("video/{videoId}")]
        public async Task<ActionResult<List<Comment>>> GetVideoComments(int videoId)
        {
            try
            {
                var comments = await _commentService.GetCommentsByVideoIdAsync(videoId);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("video/{videoId}")]
        public async Task<IActionResult> AddComment(int videoId, [FromBody] CommentDto request)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                await _commentService.AddCommentAsync(userId, videoId, request.Content);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}