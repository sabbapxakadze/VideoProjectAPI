//using ApplicationLib.DTOs.Video;
//using DomainLib.Interfaces;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.IO; // You'll likely need this for Path operations
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using ApplicationLib.Interfaces;

//namespace ApplicationLib.Services
//{
//    public class VideoService : IVideoService
//    {
//        private readonly IVideoRepository _videoRepository;
//        private readonly IConfiguration _configuration;

//        public VideoService(
//            IVideoRepository videoRepository,
//            IConfiguration configuration)
//        {
//            _videoRepository = videoRepository;
//            _configuration = configuration;
//        }

//        public async Task<List<Video>> GetAllVideosAsync()
//        {
//            return await _videoRepository.GetAllVideosAsync();
//        }

//        public async Task<VideoUploadResult> UploadVideoAsync(IFormFile file, string title, string description)
//        {
//            if (file == null || file.Length == 0)
//                throw new ArgumentException("No file uploaded.");

//            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedVideos");
//            if (!Directory.Exists(uploadDirectory))
//            {
//                Directory.CreateDirectory(uploadDirectory);
//            }

//            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
//            var filePath = Path.Combine(uploadDirectory, uniqueFileName);

//            using (var stream = new FileStream(filePath, FileMode.Create))
//            {
//                await file.CopyToAsync(stream);
//            }

//            var video = new Video
//            {
//                Title = title,
//                FilePath = Path.Combine("UploadedVideos", uniqueFileName),
//                UploadedAt = DateTime.UtcNow,
//                Description = description
//            };

//            await _videoRepository.AddVideoAsync(video);
//            await _videoRepository.SaveChangesAsync();

//            return new VideoUploadResult
//            {
//                FileName = uniqueFileName,
//                VideoId = video.Id
//            };
//        }

//        public async Task<bool> DeleteVideoAsync(int id)
//        {
//            var video = await _videoRepository.GetVideoByIdAsync(id);
//            if (video == null)
//                throw new KeyNotFoundException("Video not found.");

//            var filePath = Path.Combine(Directory.GetCurrentDirectory(), video.FilePath.TrimStart('/'));
//            if (System.IO.File.Exists(filePath))
//            {
//                System.IO.File.Delete(filePath);
//            }

//            await _videoRepository.DeleteVideoAsync(video);
//            return await _videoRepository.SaveChangesAsync();
//        }
//    }
//}
