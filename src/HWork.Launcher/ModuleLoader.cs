using System.Reflection;

namespace HWork.Launcher;

public static class ModuleLoader
{
    public static IReadOnlyCollection<IModule> LoadModules(IConfiguration configuration)
    {
        var enabledModules = configuration.GetEnabledModules();
        
        return Directory
            .GetFiles(
                AppDomain.CurrentDomain.BaseDirectory,
                "HWork.*.Api.dll")
            .Select(Assembly.LoadFrom)
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type =>
                typeof(IModule).IsAssignableFrom(type)
                && !type.IsInterface)
            .OrderBy(type => type.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .Where(module =>
                enabledModules.Contains(module.Name))
            .ToList();
    }
}
