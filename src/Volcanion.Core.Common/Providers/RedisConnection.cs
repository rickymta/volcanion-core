using StackExchange.Redis;

namespace Volcanion.Core.Common.Providers;

public class RedisConnection
{
    public static IConnectionMultiplexer Connect(string connectionString)
    {
        return ConnectionMultiplexer.Connect(connectionString);
    }
}
