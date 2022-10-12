using project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(ApplicationUser user);
        Task<int> DeleteAsync(ApplicationUser user);
        Task<int> UpdateAsync(ApplicationUser user);
        Task<ApplicationUser> FindByIdAsync(int userId);
        Task<ApplicationUser> FindByNameAsync(string normalizedUserName);
        Task<ApplicationUser> FindByEmailAsync(string normalizedEmail);
        Task AddToRoleAsync(ApplicationUser user, string roleName);
        Task RemoveFromRoleAsync(ApplicationUser user, string roleName);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
        Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName);
    }
}
