using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PublicSharing.Domain.DomainItems;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using PublicSharing.Infrastructure.Persistence.EventStore;
using PublicSharing.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PublicSharingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PublicSharingDbContext"));
            });
            var mongoClient = new MongoClient(configuration.GetConnectionString("PublicSharingEventStore"));
           var mongoDatabase =mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            services.AddTransient<IEventStore>(provider => new MongoDbEventStore(mongoDatabase));
            services.AddTransient<IUserRepository, UserRepositpry>();
            services.AddTransient<ITweetRepository,TweetRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();



            return services;
        }
    }
}
