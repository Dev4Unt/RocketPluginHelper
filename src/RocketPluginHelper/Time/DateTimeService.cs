namespace RocketPluginHelper.Time;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class DateTimeService
{
    public static DateTimeOffset UtcNow()
    {
        return DateTime.UtcNow;
    }
}