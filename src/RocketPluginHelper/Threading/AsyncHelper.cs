namespace RocketPluginHelper.Threading;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class AsyncHelper
{
    public static void Schedule<TContext>(Func<Task> task, Action<Exception>? exceptionHandler = null)
    {
        Schedule(typeof(TContext).FullName, task, exceptionHandler);
    }
    public static void Schedule(string name, Func<Task> task, Action<Exception>? exceptionHandler = null)
    {
        Task.Run(async () =>
        {
            try
            {
                await task();
            }
            catch (Exception ex)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler(ex);
                }
                else
                {
                    Console.WriteLine($"Exception occured in task \"{name}\", {ex}");
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