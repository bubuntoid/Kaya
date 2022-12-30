namespace Kaya;

public interface IKayaHttpClient
{
    Task<HttpResponseMessage> LogAsync(Event obj);
}