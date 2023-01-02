// ReSharper disable once CheckNamespace
namespace Kaya;

public static class DebugExtensions
{
    public static void LogDebug(IKayaContext context, string message, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogDebug(context, message, string.Empty, tags, headers);

    public static void LogDebug(this IKayaContext context, string message, Exception ex, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogDebug(context, message, ex.ToContentString(), tags, headers);

    public static void LogDebug(this IKayaContext context, string message, string content, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        context.LogWithTag(KayaTags.Debug, message, content, headers, tags);
}