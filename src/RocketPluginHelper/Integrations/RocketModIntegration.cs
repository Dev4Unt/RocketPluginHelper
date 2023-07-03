namespace RocketPluginHelper.Integrations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class RocketModIntegration
{
    public static bool IsRocketModUnturnedLoaded(out Assembly? assembly)
    {
        return (assembly = AppDomain.CurrentDomain.GetAssemblies().LastOrDefault(IsRocketModUnturnedAssembly)) != null;
    }
    public static bool IsRocketModUnturnedAssembly(Assembly assembly)
    {
        return assembly.GetName().Name.Equals("Rocket.Unturned");
    }
}