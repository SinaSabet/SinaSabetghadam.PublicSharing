using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.IntegrationTests.DbSettings
{
    public abstract class EfDatabaseBaseFixture<TDbContext>
        : IDisposable where TDbContext : DbContext
    {
        public TDbContext BuildDbContext(string dbName)
        {
            try
            {
                var _options = new DbContextOptionsBuilder<TDbContext>()
                                .UseInMemoryDatabase(dbName)
                                .EnableSensitiveDataLogging()
                                .Options;

                var db = BuildDbContext(_options);
                db.Database.EnsureCreated();

                return BuildDbContext(_options);
            }
            catch (Exception ex)
            {
                throw new Exception($"unable to connect to db.", ex);
            }
        }

        protected abstract TDbContext BuildDbContext(DbContextOptions<TDbContext> options);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
