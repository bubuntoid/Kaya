namespace Kaya.Service.WebAPI.Contracts.Project.Dashboard;

public class EventHeaderFrequencyRateDto
{
    public string HeaderValue { get; set; }
    
    public string Count { get; set; }
    
    public decimal DifferenceInPercentage { get; set; }
}