namespace Kaya.Service.Domain.Models.Dashboard;

public class ProjectDashboard
{
    public IDictionary<string, ICollection<DateTime>> Tags { get; set; } = new Dictionary<string, ICollection<DateTime>>();

    public IDictionary<string, ICollection<DateTime>> Headers { get; set; } = new Dictionary<string, ICollection<DateTime>>();
    
    public IDictionary<string, ICollection<DateTime>> HeaderValues { get; set; } = new Dictionary<string, ICollection<DateTime>>();
}