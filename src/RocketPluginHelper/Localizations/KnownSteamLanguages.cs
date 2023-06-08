namespace RocketPluginHelper.Localizations;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[SuppressMessage("ReSharper", "ConvertIfStatementToReturnStatement")]
public static class KnownSteamLanguages
{
    public const string EnglishLanguageName = "English";
    public const string RussianLanguageName = "Russian";
    public const string EnglishLanguageCode = "en";
    public const string RussianLanguageCode = "ru";
    public const string UnderscoreSymbol = "_";
    public static readonly Dictionary<string, string> Languages = new()
    {
        { EnglishLanguageCode, EnglishLanguageName},
        { RussianLanguageCode, RussianLanguageName},
    };
    public static readonly Language English = new(EnglishLanguageName, EnglishLanguageCode);
    public static readonly Language Russian = new(RussianLanguageName, RussianLanguageCode);

    public static string? GetLanguageCodeFromName(string name)
    {
        if (Languages.Any(l => l.Value.Equals(name, StringComparison.OrdinalIgnoreCase)) == false)
        {
            return null;
        }
        return Languages.First(l => l.Value.Equals(name, StringComparison.OrdinalIgnoreCase)).Key;
    }
}