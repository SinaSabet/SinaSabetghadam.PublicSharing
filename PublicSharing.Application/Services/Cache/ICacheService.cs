using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Services.Cache
{
    public interface ICacheService
    {
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> createItem, int duration);
        void Add<T>(string key, T value);
        void Remove<T>(string key);
    }
}
