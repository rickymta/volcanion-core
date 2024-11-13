namespace Volcanion_Core_Common.Abstractions;

/// <summary>
/// IRedisCacheProvider
/// </summary>
public interface IRedisCacheProvider
{
    /// <summary>
    /// GetCacheAsync
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<T> GetCacheAsync<T>(string key);

    /// <summary>
    /// SetCacheAsync
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task<T> SetCacheAsync<T>(string key, T value);
}
