namespace HWork.Launcher;

public static class WebApplicationExtension
{
    public static WebApplication Configure(
        this WebApplication webApplication,
        IReadOnlyCollection<IModule> modules)
    {
        foreach (var module in modules)
        {
            module.UseModuleMiddlewares(webApplication);
        }

        webApplication.MapControllers();
        webApplication.AddModulesInfoEndpoint();

        return webApplication;
    }

    private static void AddModulesInfoEndpoint(this WebApplication webApplication)
    {
        webApplication.MapGet("modules", context =>
        {
            var enabledModules = webApplication.Configuration.GetEnabledModules();
            return context.Response.WriteAsJsonAsync(enabledModules);
        });
    }
}