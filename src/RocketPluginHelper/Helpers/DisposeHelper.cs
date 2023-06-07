namespace RocketPluginHelper.Helpers;

[SuppressMessage("ReSharper", "ConvertIfStatementToSwitchStatement")]
public static class DisposeHelper
{
    public static async Task DisposeAllAsync(this IEnumerable<object> objects)
    {
        foreach (var @object in objects)
        {
            if (@object is IAsyncDisposable asyncDisposable)
            {
                await asyncDisposable.DisposeAsync();
            }
            else if (@object is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
    public static async Task DisposeAllAsync(this List<object> objects)
    {
        for (var i = 0; i < objects.Count; i++)
        {
            var @object = objects[i];
            if (@object is IAsyncDisposable asyncDisposable)
            {
                await asyncDisposable.DisposeAsync();
            }
            else if (@object is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
    public static void DisposeAll(this IEnumerable<object> objects)
    {
        foreach (var @object in objects)
        {
            if (@object is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
    public static async Task DisposeSyncOrAsync(this object o)
    {
        if (o is IAsyncDisposable asyncDisposable)
        {
            await asyncDisposable.DisposeAsync();
        }
        else if (o is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}