using System.Net.Http.Json;

namespace Kaya;

public class KayaHttpClient : IKayaHttpClient
{
    private readonly IKayaCredentials credentials;
    private readonly HttpClient client;

    public KayaHttpClient(IKayaCredentials credentials)
    {
        this.credentials = credentials;
        client = new HttpClient();
    }
    
    public Task<HttpResponseMessage> LogAsync(Event obj)
    {
        var baseUri = new Uri(credentials.Endpoint);
        var uri = new Uri(baseUri, "api/event/log");
        return client.PostAsJsonAsync(uri, obj);
    }
}