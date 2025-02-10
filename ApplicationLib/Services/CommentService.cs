using ApplicationLib.Interfaces;
using DomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLib.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetCommentsByVideoIdAsync(int videoId)
        {
            return await _commentRepository.GetCommentsByVideoIdAsync(videoId);
        }

        public async Task AddCommentAsync(string userId, int videoId, string content)
        {
            var comment = new Comment { UserId = userId, VideoId = videoId, Content = content };
            await _commentRepository.AddCommentAsync(comment);
        }
    }
}
