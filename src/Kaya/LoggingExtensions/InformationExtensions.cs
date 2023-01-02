// ReSharper disable once CheckNamespace
namespace Kaya;

public static class InformationExtensions
{
    public static void LogInformation(IKayaContext context, string message, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogInformation(context, message, string.Empty, tags, headers);

    public static void LogInformation(this IKayaContext context, string message, Exception ex, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        LogInformation(context, message, ex.ToContentString(), tags, headers);

    public static void LogInformation(this IKayaContext context, string message, string content, IEnumerable<string> tags = null, IDictionary<string, string> headers = null) =>
        context.LogWithTag(KayaTags.Information, message, content, headers, tags);
}