using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLib.Interfaces
{
    public interface ILikeService
    {
        Task<int> GetLikeCountAsync(int videoId);
        Task LikeVideoAsync(string userId, int videoId);
        Task UnlikeVideoAsync(string userId, int videoId);
    }
}