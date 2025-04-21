using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations;

/// <inheritdoc/>
public class ConfigProvider : IConfigProvider
{
    /// <summary>
    /// Logger
    /// </summary>
    private ILogger<ConfigProvider> _logger { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    public ConfigProvider(ILogger<ConfigProvider> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc/>
    public object? GetConfig(string key)
    {
        try
        {
            var path = Directory.GetCurrentDirectory();
            string text = File.ReadAllText($@"{path}\\config.json");
            dynamic d = JObject.Parse(text);
            return d[key];
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[ConfigProvider][GetConfig] Error on provider");
            return null;
        }
    }

    /// <inheritdoc/>
    public string? GetConfigString(string key)
    {
        try
        {
            return GetConfig(key)?.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[ConfigProvider][GetConfigString] Error on provider");
            return null;
        }
    }

    /// <inheritdoc/>
    public void SaveConfig(object data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(@"config.json", json);
    }
}
