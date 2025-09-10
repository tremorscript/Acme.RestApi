using Acme.SampleToDo.Infrastructure.Data;
using Acme.SampleToDo.Web.Configurations;
using Acme.SampleToDo.Web.Projects;
using FluentValidation;
using NimblePros.Metronome;
using ServiceConfig = Ardalis.ListStartupServices.ServiceConfig;

public partial class Program
{
  public static async Task Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    var logger = Log.Logger = new LoggerConfiguration()
      .Enrich.FromLogContext()
      .WriteTo.Console()
      .CreateLogger();
    logger.Information("Starting web host");

    builder.AddLoggerConfigs();


    var appLogger = new SerilogLoggerFactory(logger)
      .CreateLogger<Program>();

    builder.Services.AddOptionConfigs(builder.Configuration, appLogger, builder);
    builder.Services.AddServiceConfigs(appLogger, builder);

    builder.Services.AddFastEndpoints()
      .SwaggerDocument(o =>
      {
        o.ShortSchemaNames = true;
      });

    builder.Services.AddValidatorsFromAssemblyContaining<UpdateProjectRequestValidator>();

    if (builder.Environment.EnvironmentName == "Development")
    {
      // verify validators are added properly
      var serviceProvider = builder.Services.BuildServiceProvider();
      var validatorsCount = serviceProvider.GetServices<IValidator<UpdateProjectRequest>>().Count();
      appLogger.LogInformation("Validators found: {validatorsCount}", validatorsCount);
    }

    if (!builder.Environment.EnvironmentName.Equals("Testing"))
    {
      var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
      builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(connectionString));
    }

    builder.Services.AddMemoryCache();


    // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
    builder.Services.Configure((ServiceConfig config) =>
    {
      config.Services = new List<ServiceDescriptor>(builder.Services);

      // optional - default path to view services is /listallservices - recommended to choose your own path
      config.Path = "/listservices";
    });

    // track db and external service calls
    builder.Services.AddMetronome();


    var app = builder.Build();

    await app.UseAppMiddleware();

    app.Run();
  }
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
