using System.Linq;
using System.Threading.Tasks;
using DevTestApi.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevTestApi.Controllers
{
    /// <summary>
    /// Admin API
    /// </summary>
    public class AdminController : BaseApiController
    {
        #region Private members

        private readonly UserManager<AppUser> _userManager;

        #endregion

        #region Constructor

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        

        #endregion
        
        #region Get users with roles

        /// <summary>
        /// Get list of users with roles
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "RequiredAdminRole")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUserWithRoles()
        {
            var user = await _userManager.Users.Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();
            return Ok(user);
        }

        #endregion

        #region Edit user roles

        /// <summary>
        ///  Edit user roles
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost("/{username}")]
        public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("Could not find user");
            var userRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
            if (!result.Succeeded) return BadRequest("Failed to add to roles");
            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
            if (!result.Succeeded) return BadRequest("Failed to remove from roles");
            return Ok(await _userManager.GetRolesAsync(user));
        }

        #endregion
    }
}