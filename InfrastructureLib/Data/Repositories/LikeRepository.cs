using DomainLib.Interfaces;
using DomainLib.Interfaces.Base;
using InfrastructureLib.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InfrastructureLib.Data.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> GetLikesByVideoIdAsync(int videoId)
        {
            return await _dbContext.Likes.CountAsync(l => l.VideoId == videoId);
        }

        public async Task<bool> HasUserLikedAsync(string userId, int videoId)
        {
            return await _dbContext.Likes.AnyAsync(l => l.UserId == userId && l.VideoId == videoId);
        }

        public async Task AddLikeAsync(string userId, int videoId)
        {
            _dbContext.Likes.Add(new Like { UserId = userId, VideoId = videoId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveLikeAsync(string userId, int videoId)
        {
            var like = await _dbContext.Likes.FirstOrDefaultAsync(l => l.UserId == userId && l.VideoId == videoId);
            if (like != null)
            {
                _dbContext.Likes.Remove(like);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}