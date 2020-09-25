using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestClient.Extensions
{
  public static class ConfigurationExtension
  {
    public static IServiceCollection SetupConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        AddConfiguration<Configuration.Camunda>(services, configuration, "camunda");
        return services;
    }

    private static void AddConfiguration<CONFIG_TYPE>(IServiceCollection services, IConfiguration configuration, string key) where CONFIG_TYPE : class, new()
    {
        services.Configure<CONFIG_TYPE>(configuration.GetSection(key));
    }

  }
}
