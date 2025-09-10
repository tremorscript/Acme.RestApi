using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Acme_SampleToDo_Web>("web");

builder.Build().Run();
