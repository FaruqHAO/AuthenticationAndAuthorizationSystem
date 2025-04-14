
using AuthenticationAndAuthorizationSystem.Server.Data;
using AuthenticationAndAuthorizationSystem.Server.Models;

namespace AuthenticationAndAuthorizationSystem.Server.Services.RolesService
{
    public interface IRoleService
    {
        Task EnsureRolesExistAsync();
        Task<List<UserWithRoles>> GetUsersWithRolesAsync();
        Task<UserWithRoles> GetUsersWithRolesByUserAsync(ApplicationUser user);
        Task<bool> SaveUserRoles(UserWithRoles user);
    }
}