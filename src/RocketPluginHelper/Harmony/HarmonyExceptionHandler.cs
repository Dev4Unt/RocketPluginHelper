namespace RocketPluginHelper.Harmony;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class HarmonyExceptionHandler
{
    public delegate void ReportCleanupRequested(Type type, Exception? exception, MethodBase? originalMethod);
    public static event ReportCleanupRequested? OnReportCleanupRequested;

    public static void ReportCleanupException(Type type, Exception? exception, MethodBase? originalMethod)
    {
        OnReportCleanupRequested?.Invoke(type, exception, originalMethod);
    }
}