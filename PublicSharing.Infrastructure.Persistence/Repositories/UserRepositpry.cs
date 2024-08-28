using Microsoft.EntityFrameworkCore;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence.Repositories
{
    public class UserRepositpry(PublicSharingDbContext dbContext) : IUserRepository
    {
        public void Add(User user) => dbContext.users.Add(user);

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken) =>
            await dbContext.users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

        public async Task<User?> GetUserByIdAsync(UserId id, CancellationToken cancellationToken)
       => await dbContext.users.FindAsync(id);

        public async Task<bool> IsExistsWithEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await dbContext.users.AnyAsync(u => u.Email == email, cancellationToken);
        }
    }
}
