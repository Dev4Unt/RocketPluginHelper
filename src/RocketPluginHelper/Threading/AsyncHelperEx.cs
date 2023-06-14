namespace RocketPluginHelper.Threading;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class AsyncHelperEx
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
                if (ex is not OperationCanceledException)
                {
                    if (exceptionHandler == null)
                    {
                        Console.WriteLine($"Exception occured in task \"{name}\", {ex}");
                    }
                    else
                    {
                        exceptionHandler(ex);
                    }
                }
            }
        });
    }
}