using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using OpenTelemetry.Metrics;

namespace PublicSharing.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            var assembly = typeof(IAssemblyMarker).Assembly;

            ServiceDescriptor[] serviceDescriptors = assembly
                .DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                               type.IsAssignableTo(typeof(IEndPoint)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndPoint), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }


        public static IApplicationBuilder MapEndpoints(this WebApplication app)
        {
            IEnumerable<IEndPoint> endpoints = app.Services
                                                  .GetRequiredService<IEnumerable<IEndPoint>>();

            foreach (IEndPoint endpoint in endpoints)
            {
                endpoint.MapEndpoint(app);
            }

            return app;
        }


        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IServiceCollection AddNlog(this IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            });

            // Add NLog as the logger provider
            services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();

            return services;
        }


   
    }
}
