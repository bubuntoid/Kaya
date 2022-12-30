namespace Kaya.Service.Domain.Models.Dashboard;

public class EventTagFrequencyRate
{
    public string TagValue { get; set; }
    
    public string Count { get; set; }
    
    public decimal DifferenceInPercentage { get; set; }
}