using System.Collections.Concurrent;
using Kaya.Extensions;

namespace Kaya;

public class KayaContext : IKayaContext
{
    private readonly IKayaHttpClient httpClient;
    private readonly IKayaCredentials credentials;
    public ICollection<string> Tags { get; } = new HashSet<string>();
    public IDictionary<string, string> Headers { get; } = new ConcurrentDictionary<string, string>();

    public KayaContext(IKayaHttpClient httpClient, IKayaCredentials credentials)
    {
        this.httpClient = httpClient;
        this.credentials = credentials;
    }

    public void AddTag(string tag)
    {
        Tags.Add(tag);
    }

    public void AddHeader(string key, string value)
    {
        Headers.Add(key, value);
    }

    public void Log(string message,
        string content = null,
        IEnumerable<string> tags = null,
        IDictionary<string, string> headers = null) =>
        httpClient.LogAsync(
            new Event
            {
                Message = message,
                PrivateKey = credentials.ProjectPrivateKey,
                Tags = Tags.ConcatIfNotNull(tags).ToList(),
                Headers = Headers.ConcatIfNotNull(headers).ToDictionary(s => s.Key, s => s.Value),
                Content = content
            }
        );
}