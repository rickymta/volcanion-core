using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Volcanion_Core_Common.Providers;

/// <summary>
/// LogProvider
/// </summary>
public static class LogProvider
{
    /// <summary>
    /// LoggerSetting
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="environment"></param>
    public static void LoggerSetting(IConfigurationRoot configuration, string? environment)
    {
        environment ??= "Development";
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
            .Enrich.WithProperty("Environment", environment)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }

    /// <summary>
    /// ConfigureElasticSink
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="environment"></param>
    /// <returns></returns>
    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
    {
        var elasticsearchUrl = configuration["ElasticConfiguration:Uri"];
        environment ??= "Development";
        elasticsearchUrl ??= "http://localhost:9200";
        return new ElasticsearchSinkOptions(new Uri(elasticsearchUrl))
        {
            AutoRegisterTemplate = true,
            IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(",", "-")}-{environment.ToLower()}-{DateTime.UtcNow:yyyy-MM}",
            NumberOfReplicas = 1,
            NumberOfShards = 2
        };
    }
}
