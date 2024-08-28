using MediatR;
using PublicSharing.Application.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Behaviors.Cache
{
    internal sealed class QueryCachingPipelineBehavior<TRequest, TResponse>(ICacheService cacheService) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequestWithCache
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var cacheKey = request.GetType().Name;
            if (cacheKey is null)
                return await next();    
           
            var cacheDuration = 60; 

            return await cacheService.GetOrCreateAsync(cacheKey, async () =>
            {
                return await next();
            }, cacheDuration);
        }
    }
}
