using System.Collections.Concurrent;

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

    public void LogError(string message)
    {
        var obj = new Event
        {
            Tags = Tags,
            Headers = Headers,
            Message = message,
            PrivateKey = credentials.ProjectPrivateKey,
        };

        httpClient.LogAsync(obj);
    }
}