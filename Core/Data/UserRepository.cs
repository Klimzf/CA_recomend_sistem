using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_recomend_sistem.Core.Data;

public class UserRepository : IUserRepository
{
    public async Task<User> GetUserByIdAsync(int userId)
    {
        var users = new List<User>
            {
                new User { Id = 1, Name = "Alice" },
                new User { Id = 2, Name = "Bob" }
            };
        return await Task.FromResult(users.FirstOrDefault(u => u.Id == userId));
    }
}
