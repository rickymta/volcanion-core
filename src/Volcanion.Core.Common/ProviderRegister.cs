using Microsoft.Extensions.DependencyInjection;
using Volcanion.Core.Common.Abstractions;
using Volcanion.Core.Common.Implementations;

namespace Volcanion.Core.Common;

/// <summary>
/// ProviderRegister
/// </summary>
public static class ProviderRegister
{
    /// <summary>
    /// AddProviderServices
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterProviders(this IServiceCollection services)
    {
        services.AddTransient<IConfigProvider, ConfigProvider>();
        services.AddTransient<ICookieProvider, CookieProvider>();
        services.AddTransient<IHashProvider, HashProvider>();
        services.AddTransient<ISafeThreadProvider, SafeThreadProvider>();
        services.AddTransient<IStringProvider, StringProvider>();
        services.AddTransient<IMemCacheProvider, MemCacheProvider>();
    }
}
