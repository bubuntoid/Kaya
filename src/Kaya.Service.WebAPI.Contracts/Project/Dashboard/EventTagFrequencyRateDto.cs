namespace Kaya.Service.WebAPI.Contracts.Project.Dashboard;

public class EventTagFrequencyRateDto
{
    public string Tag { get; set; }
    
    public string Count { get; set; }
    
    public decimal DifferenceInPercentage { get; set; }
}