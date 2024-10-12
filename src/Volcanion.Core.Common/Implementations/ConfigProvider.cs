using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations
{
    public class ConfigProvider : IConfigProvider
    {
        /// <summary>
        /// Logger
        /// </summary>
        private ILogger<ConfigProvider> Logger { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public ConfigProvider(ILogger<ConfigProvider> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// GetConfig
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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
                Logger.LogError("error", ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// GetConfigString
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? GetConfigString(string key)
        {
            try
            {
                return GetConfig(key)?.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError("error", ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// SaveConfig
        /// </summary>
        /// <param name="data"></param>
        public void SaveConfig(object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(@"config.json", json);
        }
    }
}
