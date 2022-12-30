using Kaya.Service.Domain.Models.Dashboard;

namespace Kaya.Service.WebAPI.Contracts.Project.Dashboard;

public class ProjectDashboardDto
{
    public IDictionary<string, ICollection<DateTime>> Tags { get; set; } = new Dictionary<string, ICollection<DateTime>>();

    public IDictionary<string, ICollection<DateTime>> Headers { get; set; } = new Dictionary<string, ICollection<DateTime>>();
    
    public IDictionary<string, ICollection<DateTime>> HeaderValues { get; set; } = new Dictionary<string, ICollection<DateTime>>();
}
