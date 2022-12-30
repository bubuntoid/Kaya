using System.Net.Http.Json;

namespace Kaya;

public class KayaHttpClient : IKayaHttpClient
{
    private readonly string endpoint;
    private readonly HttpClient client;

    public KayaHttpClient(string endpoint)
    {
        this.endpoint = endpoint;
        client = new HttpClient();
    }
    
    public Task<HttpResponseMessage> LogAsync(Event obj)
    {
        var baseUri = new Uri(endpoint);
        var uri = new Uri(baseUri, "api/event/log");
        return client.PostAsJsonAsync(uri, obj);
    }
}