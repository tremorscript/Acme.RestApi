using Acme.SampleToDo.Core.Interfaces;
using Acme.SampleToDo.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.SampleToDo.Core;

public static class CoreServiceExtensions
{
  
  public static IServiceCollection AddCoreServices(this IServiceCollection services, ILogger logger)
  {
    services.AddScoped<IToDoItemSearchService, ToDoItemSearchService>();
    services.AddScoped<IDeleteContributorService, DeleteContributorService>();
    
    logger.LogInformation("{Project} services registered", "Core");

    return services;
  }
  
}
