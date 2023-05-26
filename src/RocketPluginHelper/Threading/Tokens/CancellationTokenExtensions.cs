namespace RocketPluginHelper.Threading.Tokens;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class CancellationTokenExtensions
{
    [SuppressMessage("ReSharper", "InvertIf")]
    public static void CancelAndDispose(this CancellationTokenSource source)
    {
        using var _ = source;
        source.Cancel();
    }
}