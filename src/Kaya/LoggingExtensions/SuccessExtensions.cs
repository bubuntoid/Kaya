// ReSharper disable once CheckNamespace
namespace Kaya;

public static class SuccessExtensions
{
    public static void LogSuccess(IKayaContext context, string message, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogSuccess(context, message, string.Empty, tags, headers);

    public static void LogSuccess(this IKayaContext context, string message, Exception ex, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogSuccess(context, message, ex.ToContentString(), tags, headers);

    public static void LogSuccess(this IKayaContext context, string message, string content, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        context.LogWithTag(KayaTags.Success, message, content, headers, tags);
}