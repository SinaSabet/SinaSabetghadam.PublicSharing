using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using PublicSharing.Application.Services.Cache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Services
{
    public class CacheService(IDistributedCache _cache) : ICacheService
    {

        private readonly TimeSpan DefaultTime = TimeSpan.FromMinutes(1);
        public void Add<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            _cache.SetString(key, serializedValue);
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> createItem, int duration)
        {
            var cachedData = await _cache.GetStringAsync(key);
            if (cachedData is not null )
            {
                return JsonSerializer.Deserialize<T>(cachedData);
            }

            var newItem = await createItem();
            await _cache.SetStringAsync(key, JsonSerializer.Serialize(newItem), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });

            return newItem;
        }

        public void Remove<T>(string key)
        {

            _cache.Remove(key);
        }
    }
}
