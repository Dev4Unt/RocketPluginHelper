namespace RocketPluginHelper.Threading;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class AsyncHelper
{
    public static void Schedule(string name, Func<Task> task, Action<Exception>? exceptionHandler = null)
    {
        Task.Run(async () =>
        {
            try
            {
                await task();
            }
            catch (Exception e)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler(e);
                }
                else
                {
                    RocketLogger.LogException(e, $"Exception occured in task \"{name}\"");
                }
            }
        });
    }
    public static TResult RunSync<TResult>(Func<Task<TResult>> func)
    {
        return AsyncContext.Run(func);
    }
    public static void RunSync(Func<Task> action)
    {
        AsyncContext.Run(action);
    }
}