using Microsoft.EntityFrameworkCore;
using PublicSharing.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.IntegrationTests.DbSettings
{
    public class PublicSharingDbContextFixture : EfDatabaseBaseFixture<PublicSharingDbContext>
    {
        protected override PublicSharingDbContext BuildDbContext(DbContextOptions<PublicSharingDbContext> options)
        {
            return new PublicSharingDbContext(options);
        }
    }
}
