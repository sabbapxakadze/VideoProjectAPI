using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Interfaces
{
    public interface IAdminRepository<T>
    {
        Task<IEnumerable<T>> GetAllUsersAsync();
        Task<T?> GetUserByIdAsync(string userId);
        Task<bool> AssignRoleAsync(string userId, string role);
    }
}
