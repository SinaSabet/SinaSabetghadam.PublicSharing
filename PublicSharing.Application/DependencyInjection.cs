using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublicSharing.Application.Behaviors;
using PublicSharing.Application.Behaviors.Cache;
using PublicSharing.Application.Services.Cache;
using PublicSharing.Application.Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PublicSharing.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            var application = typeof(IAssemblyMarker);

            services.AddMediatR(configure =>
            {
                configure.RegisterServicesFromAssembly(application.Assembly);
                configure.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                configure.AddOpenBehavior(typeof(QueryCachingPipelineBehavior<,>));
            });




            return services;
        }
    }
}
