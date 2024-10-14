var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder
    .Services
    .AddInfrastructureDependencies();

await webApplicationBuilder
    .Build()
    .UseSharedInfrastructureMiddlewares()
    .RunAsync();
