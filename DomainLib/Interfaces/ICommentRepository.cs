using DomainLib.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByVideoIdAsync(int videoId);
        Task AddCommentAsync(Comment comment);
    }
}
