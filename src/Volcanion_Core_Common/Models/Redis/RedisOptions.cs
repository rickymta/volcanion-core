namespace Volcanion_Core_Common.Models.Redis;

/// <summary>
/// RedisOptions
/// </summary>
public class RedisOptions
{
    /// <summary>
    /// Hostname
    /// </summary>
    public string Hostname { get; set; } = null!;

    /// <summary>
    /// InstanceName
    /// </summary>
    public string InstanceName { get; set; } = null!;

    /// <summary>
    /// AbsoluteExpireTime
    /// </summary>
    public TimeSpan AbsoluteExpireTime { get; set; }

    /// <summary>
    /// SlidingExpireTime
    /// </summary>
    public TimeSpan SlidingExpireTime { get; set; }
}
