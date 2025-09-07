using Acme.Sample.ToDo.UseCases.Contributors.Queries.List;
using Acme.Sample.ToDo.UseCases.Projects.ListIncompleteItems;
using Acme.Sample.ToDo.UseCases.Projects.ListShallow;
using Acme.SampleToDo.Core.Interfaces;
using Acme.SampleToDo.Infrastructure.Data;
using Acme.SampleToDo.Infrastructure.Data.Queries;
using Acme.SampleToDo.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using NimblePros.Metronome;

namespace Acme.SampleToDo.Infrastructure;

public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    IConfiguration configuration,
    ILogger logger,
    string environmentName)
  {
    if (environmentName == "Development")
    {
      RegisterDevelopmentOnlyDependencies(services, configuration);
    }
    else if (environmentName == "Testing")
    {
      RegisterTestingOnlyDependencies(services);
    }
    else
    {
      RegisterProductionOnlyDependencies(services, configuration);
    }
    
    RegisterEFRepositories(services);
    
    logger.LogInformation("{Project} services registered", "Infrastructure");
    
    return services;
  }
  private static void AddDbContextWithSqlite(IServiceCollection services, IConfiguration configuration)
  {
    services.AddScoped<EventDispatchInterceptor>();
    var connectionString = configuration.GetConnectionString("SqliteConnection");
    services.AddDbContext<AppDbContext>((provider, options) =>
    {
      
      options.UseSqlite(connectionString)
             .AddMetronomeDbTracking(provider)
             .AddInterceptors(provider.GetRequiredService<EventDispatchInterceptor>());
    });
             
  }


  private static void RegisterDevelopmentOnlyDependencies(IServiceCollection services, IConfiguration configuration)
  {
    AddDbContextWithSqlite(services, configuration);
    services.AddScoped<IEmailSender, SmtpEmailSender>();
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IListIncompleteItemsQueryService, ListIncompleteItemsQueryService>();
    services.AddScoped<IListProjectsShallowQueryService, ListProjectsShallowQueryService>();
  }

  private static void RegisterTestingOnlyDependencies(IServiceCollection services)
  {
    // do not configure a DbContext here for testing - it's configured in CustomWebApplicationFactory

    services.AddScoped<IEmailSender, FakeEmailSender>();
    services.AddScoped<IListContributorsQueryService, FakeListContributorsQueryService>();
    services.AddScoped<IListIncompleteItemsQueryService, FakeListIncompleteItemsQueryService>();
    services.AddScoped<IListProjectsShallowQueryService, FakeListProjectsShallowQueryService>();
  }

  private static void RegisterProductionOnlyDependencies(IServiceCollection services, IConfiguration configuration)
  {
    AddDbContextWithSqlite(services, configuration);

    services.AddScoped<IEmailSender, SmtpEmailSender>();
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IListIncompleteItemsQueryService, ListIncompleteItemsQueryService>();
    services.AddScoped<IListProjectsShallowQueryService, ListProjectsShallowQueryService>();
  }

  private static void RegisterEFRepositories(IServiceCollection services)
  {
    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
  }
}
