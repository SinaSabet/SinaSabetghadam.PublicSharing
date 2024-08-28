using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublicSharing.Application.Services.Cache;
using PublicSharing.Application.Services.Jwt;
using PublicSharing.Infrastructure.Services;

namespace PublicSharing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(configuration)
            .AddAuthorization()
            .AddHttpContextAccessor();
            
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
            services.AddScoped<ICacheService, CacheService>();

            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<ICurrentUserProvider, CurrentUserProvider>();



            services
       .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
       .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer();
     



            return services;
        }

    }
}
