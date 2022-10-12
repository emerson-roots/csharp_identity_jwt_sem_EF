using project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Repository
{
    public class UserRepository
    {
        private readonly DbSession _conn;

        public UserRepository(DbSession conn) => _conn = conn;

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            var list = await _conn.Database.Connection.Table<ApplicationUser>().ToListAsync();
            return list;
        }
    }
}
