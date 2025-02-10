using ApplicationLib.Interfaces;
using DomainLib.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLib.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository<IdentityUser> _userRepository;

        public AdminService(IAdminRepository<IdentityUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Get a user by ID
        public async Task<IdentityUser?> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        // Assign role to user
        public async Task<bool> AssignRoleAsync(string userId, string role)
        {
            return await _userRepository.AssignRoleAsync(userId, role);
        }
    }
}
