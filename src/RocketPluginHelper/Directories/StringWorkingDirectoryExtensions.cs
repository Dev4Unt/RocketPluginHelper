namespace RocketPluginHelper.Directories;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class StringWorkingDirectoryExtensions
{
    private const string WorkingDirectoryMarker = "{WorkingDirectory}";

    public static string ReplaceWorkingDirectory(this string source, string to)
    {
        return source.Replace(WorkingDirectoryMarker, to);
    }
}