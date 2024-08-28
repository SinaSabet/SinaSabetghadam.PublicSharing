using Microsoft.EntityFrameworkCore;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using PublicSharing.Infrastructure.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence
{
    public class PublicSharingDbContext: DbContext
    {
        public PublicSharingDbContext(DbContextOptions<PublicSharingDbContext> dbContextOptions)
           : base(dbContextOptions)
        {

        }
        public DbSet<Tweet> tweets { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PublicTweet");
            
            var infrastructureAssembly = typeof(IAssemblyMarker).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly);
        }
    }
}
