var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CleanArchitecture_WebAPI>("cleanarchitecture-webapi");

builder.Build().Run();
