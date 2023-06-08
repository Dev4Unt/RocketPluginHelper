namespace RocketPluginHelper.Localizations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class LanguageTranslation
{
    private readonly IAsset<TranslationList> _translations;

    public LanguageTranslation(IAsset<TranslationList> translations)
    {
        _translations = translations;
    }

    public string Translate(Player player, string key, params object[] placeHolder)
    {
        return Translate(player.channel.owner, key, placeHolder);
    }
    public string Translate(SteamPlayer steamPlayer, string key, params object[] placeHolder)
    {
        var code = KnownSteamLanguages.GetLanguageCodeFromName(steamPlayer.language) ??
                   KnownSteamLanguages.EnglishLanguageCode;
        return Translate(code, key, placeHolder);
    }
    public string Translate(string localizationCode, string key, params object[] placeHolder)
    {
        return CombineAndTranslate(localizationCode, key, placeHolder);
    }
    private string CombineAndTranslate(string localizationCode, string key, params object[] placeHolder)
    {
        return _translations.Instance.Translate($"{localizationCode}{KnownSteamLanguages.UnderscoreSymbol}{key}",
            placeHolder);
    }
}