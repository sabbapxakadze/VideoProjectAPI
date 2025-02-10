//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DomainLib.Interfaces
//{
//    public interface IVideoRepository
//    {
//        Task<List<Video>> GetAllVideosAsync();
//        Task<Video> GetVideoByIdAsync(int id);
//        Task<Video> AddVideoAsync(Video video);
//        Task DeleteVideoAsync(Video video);
//        Task<bool> SaveChangesAsync();
//    }
//}




///////////////////////////////////////////////////////////////////

//using ApplicationLib.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Hosting;
//using System.IO;
//using System.Threading.Tasks;
//using Swashbuckle.AspNetCore.Annotations;
//using System.Runtime.InteropServices;


//namespace WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class VideoController : ControllerBase
//    {
//        private readonly IVideoService _videoService;

//        public VideoController(IVideoService videoService)
//        {
//            _videoService = videoService;
//        }

//        [HttpGet]
//        [Authorize(Roles = "User,Admin")]
//        public async Task<IActionResult> GetVideos()
//        {
//            try
//            {
//                var videos = await _videoService.GetAllVideosAsync();
//                return Ok(videos);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpPost("upload")]
//        [Authorize(Roles = "Admin")]
//        public async Task<IActionResult> UploadVideo([FromForm] IFormFile file,
//            [FromForm] string title,
//            [FromForm] string description)
//        {
//            try
//            {
//                var result = await _videoService.UploadVideoAsync(file, title, description);
//                return Ok(result);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpDelete("{id}")]
//        [Authorize(Roles = "Admin")]
//        public async Task<IActionResult> DeleteVideo(int id)
//        {
//            try
//            {
//                await _videoService.DeleteVideoAsync(id);
//                return Ok("Video deleted successfully.");
//            }
//            catch (KeyNotFoundException ex)
//            {
//                return NotFound(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }
//    }
//}