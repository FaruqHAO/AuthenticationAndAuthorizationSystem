using AuthenticationAndAuthorizationSystem.Server.Data;
using AuthenticationAndAuthorizationSystem.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace AuthenticationAndAuthorizationSystem.Server.Services.RolesService
{
    public class RoleService : IRoleService
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task EnsureRolesExistAsync()
        {
            foreach (var role in AuthenticationInitalData.AppRoles)
            {
                if (!await _roleManager.RoleExistsAsync(role.Name))
                {
                    await _roleManager.CreateAsync(role);
                }
            }
        }
        public async Task<bool> SaveUserRoles(UserWithRoles user)
        {
            var userToUpdate = await _userManager.FindByIdAsync(user.UserId);
            if (userToUpdate != null)
            {
                var userWithOldRoles = await GetUsersWithRolesByUserAsync(userToUpdate);
                if (!string.IsNullOrEmpty(userWithOldRoles.RoleName))
                {
                    await _userManager.RemoveFromRoleAsync(userToUpdate, userWithOldRoles.RoleName);
                }

                if (!string.IsNullOrEmpty(user.RoleName)) {
                    await _userManager.AddToRoleAsync(userToUpdate, user.RoleName);
                }
                return true;
            }
            return false;
        }
        public async Task<List<UserWithRoles>> GetUsersWithRolesAsync()
        {
            var users = _userManager.Users.ToList();
            var userWithRolesList = new List<UserWithRoles>();

            foreach (var user in users)
            {
                var userWithRoles = new UserWithRoles
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };
                var roles = await _userManager.GetRolesAsync(user);
                if(roles.Count > 0)
                {
                    userWithRoles.RoleName = roles.FirstOrDefault();
                }
                userWithRolesList.Add(userWithRoles);
            }

            return userWithRolesList;
        }
        public async Task<UserWithRoles> GetUsersWithRolesByUserAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return new UserWithRoles
            {
                UserId = user.Id,
                UserName = user.UserName,
                RoleName = roles.FirstOrDefault()
            };
        }
    }
}
