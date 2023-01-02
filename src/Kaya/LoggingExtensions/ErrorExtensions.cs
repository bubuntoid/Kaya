// ReSharper disable once CheckNamespace
namespace Kaya;

public static class ErrorExtensions
{
    public static void LogError(IKayaContext context, string message, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogError(context, message, string.Empty, tags, headers);

    public static void LogError(this IKayaContext context, string message, Exception ex, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogError(context, message, ex.ToContentString(), tags, headers);

    public static void LogError(this IKayaContext context, string message, string content, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        context.LogWithTag(KayaTags.Error, message, content, headers, tags);
}