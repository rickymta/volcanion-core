namespace Volcanion.Core.Common.Abstractions;

/// <summary>
/// IRedisCacheProvider
/// </summary>
public interface IRedisCacheProvider
{
    /// <summary>
    /// SetStringAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task SetStringAsync(string key, string value);

    /// <summary>
    /// GetStringAsync
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<string> GetStringAsync(string key);

    /// <summary>
    /// SetHashAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task SetHashAsync(string key, string field, string value);

    /// <summary>
    /// GetHashAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="field"></param>
    /// <returns></returns>
    Task<string> GetHashAsync(string key, string field);

    /// <summary>
    /// KeyExistsAsync
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<bool> KeyExistsAsync(string key);

    /// <summary>
    /// DeleteKeyAsync
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task DeleteKeyAsync(string key);
}
