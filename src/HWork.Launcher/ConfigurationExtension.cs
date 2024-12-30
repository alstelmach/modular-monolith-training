namespace HWork.Launcher;

public static class ConfigurationExtension
{
    public static string[] GetEnabledModules(this IConfiguration configuration) =>
        configuration
            .GetSection("Modules")
            .Get<string[]>()
            ?? [];
}
