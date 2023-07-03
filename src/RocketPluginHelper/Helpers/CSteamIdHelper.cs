namespace RocketPluginHelper.Helpers;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class CSteamIdHelper
{
    public static CSteamID GetSteamId(this IRocketPlayer rocketPlayer)
    {
        if (rocketPlayer is UnturnedPlayer unturnedPlayer)
        {
            return unturnedPlayer.CSteamID;
        }
        return Provider.server;
    }
}