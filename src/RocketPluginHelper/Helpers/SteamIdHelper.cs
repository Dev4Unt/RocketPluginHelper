namespace RocketPluginHelper.Helpers;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class SteamIdHelper
{
    public static CSteamID GetSteamId(this IRocketPlayer source)
    {
        if (source is UnturnedPlayer unturnedPlayer)
        {
            return unturnedPlayer.CSteamID;
        }
        return Provider.server;
    }
    public static CSteamID GetSteamId(this Player source)
    {
        return source.channel.owner.GetSteamId();
    }
    public static CSteamID GetSteamId(this SteamPlayer source)
    {
        return source.playerID.steamID;
    }
}