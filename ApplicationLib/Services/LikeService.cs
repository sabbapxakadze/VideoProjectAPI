using ApplicationLib.Interfaces;
using DomainLib.Interfaces;
using System;
using System.Threading.Tasks;

namespace ApplicationLib.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<int> GetLikeCountAsync(int videoId)
        {
            return await _likeRepository.GetLikesByVideoIdAsync(videoId);
        }

        public async Task LikeVideoAsync(string userId, int videoId)
        {
            // Check if the user has already liked the video
            bool hasLiked = await _likeRepository.HasUserLikedAsync(userId, videoId);
            if (hasLiked)
            {
                throw new InvalidOperationException("User has already liked this video.");
            }
            await _likeRepository.AddLikeAsync(userId, videoId);
        }

        public async Task UnlikeVideoAsync(string userId, int videoId)
        {
            await _likeRepository.RemoveLikeAsync(userId, videoId);
        }
    }
}