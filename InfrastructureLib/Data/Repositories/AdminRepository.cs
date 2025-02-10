using DomainLib.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLib.Data.Repositories
{
    public class AdminRepository : IAdminRepository<IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _dbContext;

        public AdminRepository(AppDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<IdentityUser?> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<bool> AssignRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }
    }
}
