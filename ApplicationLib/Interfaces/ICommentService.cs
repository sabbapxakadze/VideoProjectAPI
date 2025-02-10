using DomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLib.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByVideoIdAsync(int videoId);
        Task AddCommentAsync(string userId, int videoId, string content);
    }
}
