using Acme.SampleToDo.Core;
using Acme.SampleToDo.Infrastructure;
using NimblePros.Metronome;

namespace Acme.SampleToDo.Web.Configurations;

public static class ServiceConfig
{
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services,
                                                     Microsoft.Extensions.Logging.ILogger logger,
                                                     WebApplicationBuilder builder)
  {
    services.AddCoreServices(logger)
            .AddInfrastructureServices(builder.Configuration, logger, builder.Environment.EnvironmentName)
            .AddMediatrConfigs();

    // add a default http client
    services.AddHttpClient("Default")
      .AddMetronomeHandler();

    logger.LogInformation("{Project} services registered", "Core and Infrastructure services registered");

    return services;
  }
}
