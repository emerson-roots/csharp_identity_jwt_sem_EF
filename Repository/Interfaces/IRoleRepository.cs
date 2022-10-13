using project.Models;
using System.Threading.Tasks;

namespace project.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<int> CreateAsync(ApplicationRole role);
        Task<int> DeleteAsync(ApplicationRole role);
        Task<int> UpdateAsync(ApplicationRole role);
        Task<ApplicationRole> FindByIdAsync(int roleId);
        Task<ApplicationRole> FindByNameAsync(string normalizedRoleName);
    }
}
