namespace RocketPluginHelper.Integrations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class OpenModIntegration
{
    public static bool IsOpenModInstalled()
    {
        const string modulesDirectoryName = "Modules";
        var modulesDirectory = Path.Combine(ReadWrite.PATH, modulesDirectoryName);
        const string rocketModuleFile = "OpenMod.Unturned.module";
        return Directory
            .GetFiles(modulesDirectory, rocketModuleFile, SearchOption.AllDirectories)
            .Any();
    }
    public static bool IsOpenModUnturnedLoaded(out Assembly? assembly)
    {
        assembly = AppDomain.CurrentDomain
            .GetAssemblies()
            .LastOrDefault(IsOpenModUnturnedAssembly);
        return assembly != null;
    }
    private static bool IsOpenModUnturnedAssembly(Assembly assembly)
    {
        const string openmodUnturnedAssemblyName = "OpenMod.Unturned";
        return assembly
            .GetName().Name
            .Equals(openmodUnturnedAssemblyName);
    }
}