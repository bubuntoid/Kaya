using Kaya.Service.Domain;

namespace Kaya.Service.WebAPI.Contracts.External;

public class EventDto : IPrivateKeyRequiredRequest
{
    public string Message { get; set; }
    
    public string Content { get; set; }
    
    public ICollection<string> Tags { get; set; }
    
    public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

    public string PrivateKey { get; set; }
}