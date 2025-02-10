using DomainLib.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Interfaces
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        Task<int> GetLikesByVideoIdAsync(int videoId);
        Task<bool> HasUserLikedAsync(string userId, int videoId);
        Task AddLikeAsync(string userId, int videoId);
        Task RemoveLikeAsync(string userId, int videoId);
    }
}
