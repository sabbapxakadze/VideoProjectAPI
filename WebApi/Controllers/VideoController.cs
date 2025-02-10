using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        public VideoController(AppDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }
        //GET
        [HttpGet]
        //[Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetVideos()
        {
            var videos = await _dbContext.Videos.ToListAsync();
            return Ok(videos);
        }
        //POST
        [HttpPost("upload")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadVideo(IFormFile file, [FromForm] string title, [FromForm] string description)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedVideos");
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }
            var filePath = Path.Combine(uploadDirectory, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var video = new Video
            {
                Title = title,
                FilePath = Path.Combine("UploadedVideos", file.FileName),
                UploadedAt = DateTime.UtcNow,
                Description = description // Add description
            };
            _dbContext.Videos.Add(video);
            await _dbContext.SaveChangesAsync();
            return Ok(new { FileName = file.FileName, VideoId = video.Id });
        }
        //DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _dbContext.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound("Video not found.");
            }
            // Delete file from server
            var filePath = Path.Combine(_env.WebRootPath, video.FilePath.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    System.IO.File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            _dbContext.Videos.Remove(video);
            await _dbContext.SaveChangesAsync();
            return Ok("Video deleted successfully.");
        }
    }
}