namespace Kaya.Service.Domain.Models.Dashboard;

public class EventHeaderFrequencyRate
{
    public string HeaderValue { get; set; }
    
    public string Count { get; set; }
    
    public decimal DifferenceInPercentage { get; set; }
}