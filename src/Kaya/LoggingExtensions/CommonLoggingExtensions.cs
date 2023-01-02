using Kaya.Extensions;

// ReSharper disable once CheckNamespace
namespace Kaya;

public static class CommonLoggingExtensions
{
    internal static string ToContentString(this Exception ex)
    {
        return ex != null ? $"{ex.Message} \n {ex.StackTrace}" : string.Empty;
    }

    internal static void LogWithTag(this IKayaContext context, 
        string baseTag, 
        string message, 
        string content = null, 
        IDictionary<string, string> headers = null, 
        IEnumerable<string> tags = null)
    {
        context.Log(message: message,
            tags: new[] { baseTag }.ConcatIfNotNull(tags),
            headers: headers,
            content: content);
    }
}