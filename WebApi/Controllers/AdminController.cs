using ApplicationLib.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("AdminOnly")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _userService;

        public AdminController(IAdminService userService)
        {
            _userService = userService;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User was not found by ID: {userId}");
            }
            return Ok(user);
        }

        [HttpPost("assignRole/{userId}")]
        public async Task<IActionResult> AssignRole(string userId, [FromBody] string role)
        {
            var result = await _userService.AssignRoleAsync(userId, role);
            if (!result)
            {
                return BadRequest("Failed to assign role.");
            }
            return Ok($"Role {role} was assigned successfully to userID:{userId}");
        }
    }
}