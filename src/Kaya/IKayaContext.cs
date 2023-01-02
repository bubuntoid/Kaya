namespace Kaya;

public interface IKayaContext
{
    ICollection<string> Tags { get; }
    IDictionary<string, string> Headers { get; }
    
    void AddTag(string tag);
    void AddHeader(string key, string value);

    public void Log(
        string message,
        string content = null,
        IEnumerable<string> tags = null,
        IDictionary<string, string> headers = null);
}