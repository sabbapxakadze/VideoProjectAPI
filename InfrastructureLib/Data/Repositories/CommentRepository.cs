using DomainLib.Interfaces;
using DomainLib.Interfaces.Base;
using InfrastructureLib.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLib.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {

        public CommentRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Comment>> GetCommentsByVideoIdAsync(int videoId)
        {
            return await _dbContext.Comments.Where(c => c.VideoId == videoId).ToListAsync();
        }

        public async Task AddCommentAsync(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
