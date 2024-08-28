using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.UserAggregate
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> IsExistsWithEmailAsync(string email,CancellationToken cancellationToken);
        Task<User?> GetUserByIdAsync(UserId id, CancellationToken cancellationToken);
    }
}
