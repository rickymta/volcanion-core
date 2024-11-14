using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Common.Models.Redis;

namespace Volcanion.Core.Common.Implementations;

/// <inheritdoc/>
public class RedisCacheProvider : IRedisCacheProvider
{
    /// <summary>
    /// IDistributedCache
    /// </summary>
    private readonly IDistributedCache _cache;

    /// <summary>
    /// RedisOptions
    /// </summary>
    private readonly IOptionsMonitor<RedisOptions> _redisOptionsMonitor;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="cache"></param>
    /// <param name="redisOptionsMonitor"></param>
    public RedisCacheProvider(IDistributedCache cache, IOptionsMonitor<RedisOptions> redisOptionsMonitor)
    {
        _cache = cache;
        _redisOptionsMonitor = redisOptionsMonitor;
    }

    /// <inheritdoc/>
    public async Task<T> GetCacheAsync<T>(string key)
    {
        var jsonData = await _cache.GetStringAsync(key);

        if (jsonData is null)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(jsonData);
    }

    /// <inheritdoc/>
    public async Task<T> SetCacheAsync<T>(string key, T value)
    {
        var optionsCache = _redisOptionsMonitor.CurrentValue;
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = optionsCache.AbsoluteExpireTime,
            SlidingExpiration = optionsCache.SlidingExpireTime
        };

        var jsonData = JsonSerializer.Serialize(value);

        await _cache.SetStringAsync(key, jsonData, options);

        return value;
    }
}
