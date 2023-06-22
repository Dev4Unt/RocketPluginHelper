namespace RocketPluginHelper.Threading;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class CancellationTokenExtensions
{
    public static void CancelAndDispose(this CancellationTokenSource source)
    {
        using var _ = source;
        source.Cancel();
    }
}