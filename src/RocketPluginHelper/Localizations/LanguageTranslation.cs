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
        return steamPlayer.language switch
        {
            KnownSteamLanguages.EnglishLanguageName => CombineAndTranslate(KnownSteamLanguages.EnglishLanguageCode, key, placeHolder),
            KnownSteamLanguages.RussianLanguageName => CombineAndTranslate(KnownSteamLanguages.RussianLanguageCode, key, placeHolder),
            _ => CombineAndTranslate(KnownSteamLanguages.EnglishLanguageCode, key, placeHolder)
        };
    }
    private string CombineAndTranslate(string code, string key, params object[] placeHolder)
    {
        return _translations.Instance.Translate($"{code}{KnownSteamLanguages.UnderscoreSymbol}{key}", placeHolder);
    }
}