namespace RocketPluginHelper.Localizations;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class Language
{
    public Language(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public string Name { get; set; }
    public string Code { get; set; }
}