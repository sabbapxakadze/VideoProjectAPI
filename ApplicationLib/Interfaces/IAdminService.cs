using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLib.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
        Task<IdentityUser?> GetUserByIdAsync(string userId);
        Task<bool> AssignRoleAsync(string userId, string role);
    }
}
