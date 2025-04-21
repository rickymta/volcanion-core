using StackExchange.Redis;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations;

/// <inheritdoc/>
public class RedisCacheProvider(IConnectionMultiplexer connectionMultiplexer) : IRedisCacheProvider
{
    /// <summary>
    /// IDatabase instance
    /// </summary>
    private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

    /// <inheritdoc/>
    public async Task SetStringAsync(string key, string value, double? expiry = 3600)
    {
        await _database.StringSetAsync(key, value, expiry: TimeSpan.FromSeconds(expiry!.Value));
    }

    /// <inheritdoc/>
    public async Task<string?> GetStringAsync(string key)
    {
        return await _database.StringGetAsync(key);
    }

    /// <inheritdoc/>
    public async Task SetHashAsync(string key, string field, string value)
    {
        await _database.HashSetAsync(key, field, value);
    }

    /// <inheritdoc/>
    public async Task<string?> GetHashAsync(string key, string field)
    {
        return await _database.HashGetAsync(key, field);
    }

    /// <inheritdoc/>
    public async Task<bool> KeyExistsAsync(string key)
    {
        return await _database.KeyExistsAsync(key);
    }

    /// <inheritdoc/>
    public async Task DeleteKeyAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }
}
