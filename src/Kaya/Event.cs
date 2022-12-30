namespace Kaya;

public class Event
{
    public string Message { get; set; }
    
    public string Content { get; set; }
    
    public ICollection<string> Tags { get; set; }
    
    public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

    public string PrivateKey { get; set; }
}