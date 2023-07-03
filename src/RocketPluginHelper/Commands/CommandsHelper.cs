namespace RocketPluginHelper.Commands;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[SuppressMessage("ReSharper", "InvertIf")]
public static class CommandsHelper
{
    public static bool TryExecuteCommand(string command)
    {
        if (RocketModIntegration.IsRocketModUnturnedLoaded(out _))
        {
            if (R.Commands.Execute(new ConsolePlayer(), command))
            {
                return true;
            }
        }
        return Commander.execute(CSteamID.Nil, command);
    }
}