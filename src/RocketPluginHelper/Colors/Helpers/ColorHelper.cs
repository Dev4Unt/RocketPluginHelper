namespace RocketPluginHelper.Colors.Helpers;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[SuppressMessage("ReSharper", "InvertIf")]
public static class ColorHelper
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public static bool TryParseRGBAString(string colorString, out UnityColor color, UnityColor? defaultColor = null)
    {
        color = defaultColor ?? UnityColor.white;
        var components = colorString
            .Replace("RGBA(", string.Empty)
            .Replace(")", string.Empty)
            .Split(',');
        if (components.Length != 4)
        {
            return false;
        }
        if (float.TryParse(components[0], out var r) &&
            float.TryParse(components[1], out var g) &&
            float.TryParse(components[2], out var b) &&
            float.TryParse(components[3], out var a))
        {
            color = new UnityColor(r, g, b, a);
            return true;
        }
        return false;
    }
}