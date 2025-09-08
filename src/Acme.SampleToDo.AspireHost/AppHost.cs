var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Acme_SampleToDo_Web>("web");

builder.Build().Run();
