//using DomainLib.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InfrastructureLib.Data.Repositories
//{
//    public class VideoRepository : IVideoRepository
//    {
//        private readonly AppDbContext _dbContext;

//        public VideoRepository(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<Video>> GetAllVideosAsync()
//        {
//            return await _dbContext.Videos.ToListAsync();
//        }

//        public async Task<Video> GetVideoByIdAsync(int id)
//        {
//            return await _dbContext.Videos.FindAsync(id);
//        }

//        public async Task<Video> AddVideoAsync(Video video)
//        {
//            await _dbContext.Videos.AddAsync(video);
//            return video;
//        }

//        public async Task DeleteVideoAsync(Video video)
//        {
//            _dbContext.Videos.Remove(video);
//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return await _dbContext.SaveChangesAsync() > 0;
//        }
//    }
//}
