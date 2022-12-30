using Kaya.Service.Domain;

namespace Kaya.Service.WebAPI.Contracts.Project.Settings;

public class ProjectSettingsSaveDto : IProjectAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }
    
    public ICollection<EventTagSettingDto> EventTags { get; set; }
}