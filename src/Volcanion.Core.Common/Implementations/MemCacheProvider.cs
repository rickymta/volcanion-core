using Microsoft.Extensions.Caching.Memory;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations
{
    /// <summary>
    /// CacheProvider
    /// </summary>
    public class MemCacheProvider : IMemCacheProvider
    {
        /// <summary>
        /// IMemoryCache
        /// </summary>
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="memoryCache"></param>
        public MemCacheProvider(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <summary>
        /// Get cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            _cache.TryGetValue(key, out var result);
            return result ?? false;
        }

        /// <summary>
        /// Set cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object Set(string key, object value)
        {
            return _cache.Set(key, value);
        }

        /// <summary>
        /// Set cache with expiration time
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public object Set(string key, object value, DateTimeOffset absoluteExpiration)
        {
            return _cache.Set(key, value, absoluteExpiration);
        }

        /// <summary>
        /// Delete cache by key
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            _cache.Remove(key);
        }
    }
}
