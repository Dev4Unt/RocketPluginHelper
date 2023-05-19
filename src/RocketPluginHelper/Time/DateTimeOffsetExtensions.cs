namespace RocketPluginHelper.Time;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class DateTimeOffsetExtensions
{
    public static string ToStringUniversal(this DateTimeOffset source)
    {
        return source.ToString("u");
    }
}