namespace Kaya.Service.WebAPI.Contracts.Project.Settings;

public class ProjectSettingsDto
{
    public ICollection<EventTagSettingDto> EventTags { get; set; }
}