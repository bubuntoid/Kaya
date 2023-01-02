// ReSharper disable once CheckNamespace
namespace Kaya;

public static class TraceExtensions
{
    public static void LogTrace(IKayaContext context, string message, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogTrace(context, message, string.Empty, tags, headers);

    public static void LogTrace(this IKayaContext context, string message, Exception ex, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogTrace(context, message, ex.ToContentString(), tags, headers);

    public static void LogTrace(this IKayaContext context, string message, string content, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        context.LogWithTag(KayaTags.Trace, message, content, headers, tags);
}