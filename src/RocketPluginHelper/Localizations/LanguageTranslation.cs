namespace RocketPluginHelper.Localizations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class LanguageTranslation
{
    private readonly TranslationList _translationList;

    public LanguageTranslation(TranslationList translationList)
    {
        _translationList = translationList;
    }

    public string Translate(Player player, string key, params object[] placeHolder)
    {
        var steamPlayer = player.channel.owner;
        return steamPlayer.language switch
        {
            KnownSteamLanguages.EnglishLanguageName => CombineAndTranslate(KnownSteamLanguages.EnglishLanguageCode, key, placeHolder),
            KnownSteamLanguages.RussianLanguageName => CombineAndTranslate(KnownSteamLanguages.RussianLanguageCode, key, placeHolder),
            _ => CombineAndTranslate(KnownSteamLanguages.EnglishLanguageCode, key, placeHolder)
        };
    }
    private string CombineAndTranslate(string code, string key, params object[] placeHolder)
    {
        return _translationList.Translate($"{code}{KnownSteamLanguages.UnderscoreSymbol}{key}", placeHolder);
    }
}