namespace RocketPluginHelper.Localizations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class KnownSteamLanguages
{
    public const string EnglishLanguageName = "English";
    public const string RussianLanguageName = "Russian";
    public const string EnglishLanguageCode = "en";
    public const string RussianLanguageCode = "ru";
    public const string UnderscoreSymbol = "_";

    public static readonly Language English = new(EnglishLanguageName, EnglishLanguageCode);
    public static readonly Language Russian = new(RussianLanguageName, RussianLanguageCode);
}