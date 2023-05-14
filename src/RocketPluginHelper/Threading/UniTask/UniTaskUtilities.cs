namespace RocketPluginHelper.Threading.UniTask;

[SuppressMessage("ReSharper", "InvertIf")]
public static class UniTaskUtilities
{
    public static void InitializeUniTask()
    {
        if (PlayerLoopHelper.IsInjectedUniTaskPlayerLoop() == false)
        {
            var unitySynchronizationContextField =
                typeof(PlayerLoopHelper).GetField("unitySynchronizationContext",
                    BindingFlags.Static | BindingFlags.NonPublic);

            // For older version of UniTask
            unitySynchronizationContextField ??=
                typeof(PlayerLoopHelper).GetField("unitySynchronizationContetext",
                    BindingFlags.Static | BindingFlags.NonPublic)
                ?? throw new Exception("Could not find PlayerLoopHelper.unitySynchronizationContext field");

            unitySynchronizationContextField.SetValue(null, SynchronizationContext.Current);

            var mainThreadIdField =
                typeof(PlayerLoopHelper).GetField("mainThreadId", BindingFlags.Static | BindingFlags.NonPublic)
                ?? throw new Exception("Could not find PlayerLoopHelper.mainThreadId field");
            mainThreadIdField.SetValue(null, Thread.CurrentThread.ManagedThreadId);

            var playerLoop = PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopHelper.Initialize(ref playerLoop);

            UniTaskScheduler.DispatchUnityMainThread = false;
        }
    }
}