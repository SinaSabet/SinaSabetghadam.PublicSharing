using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PublicSharing.Domain.DomainItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence
{
    public class UnitOfWork(PublicSharingDbContext publicSharingDbContext) : IUnitOfWork
    {
        private readonly PublicSharingDbContext _dbContext = publicSharingDbContext;
        private IDbContextTransaction _transaction ;

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                await BeginTransactionAsync(cancellationToken);
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext.Dispose();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }
    }
}
