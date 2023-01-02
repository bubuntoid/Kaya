// ReSharper disable once CheckNamespace
namespace Kaya;

public static class WarningExtensions
{
    public static void LogWarning(IKayaContext context, string message, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogWarning(context, message, string.Empty, tags, headers);

    public static void LogWarning(this IKayaContext context, string message, Exception ex, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogWarning(context, message, ex.ToContentString(), tags, headers);

    public static void LogWarning(this IKayaContext context, string message, string content, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        context.LogWithTag(KayaTags.Warning, message, content, headers, tags);
}