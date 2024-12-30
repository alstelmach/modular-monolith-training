var webApplicationBuilder = WebApplication.CreateBuilder(args);
var modules = ModuleLoader.LoadModules(webApplicationBuilder.Configuration);

foreach (var module in modules)
{
    module.AddModuleDependencies(webApplicationBuilder.Services);
}

webApplicationBuilder
    .Services
    .AddInfrastructureDependencies(webApplicationBuilder.Configuration);

await webApplicationBuilder
    .Build()
    .UseSharedInfrastructureMiddlewares()
    .Configure(modules)
    .RunAsync();
