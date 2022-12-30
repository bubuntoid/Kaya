namespace Kaya;

public interface IKayaContext
{
    ICollection<string> Tags { get; }
    IDictionary<string, string> Headers { get; }
    
    void AddTag(string tag);
    void AddHeader(string key, string value);
}