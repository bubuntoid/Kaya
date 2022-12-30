using AutoMapper;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Models;
using Kaya.Service.Domain.Models.Dashboard;
using Kaya.Service.WebAPI.Contracts.Project;
using Kaya.Service.WebAPI.Contracts.Project.Dashboard;
using Kaya.Service.WebAPI.Contracts.Project.Settings;
using Kaya.Service.WebAPI.Contracts.User;

namespace Kaya.Service.WebAPI;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Project, ProjectDto>();

        CreateMap<User, LoginResultDto>();

        CreateMap<ProjectSettings, ProjectSettingsDto>()
            .ForMember(s => s.EventTags, cfg => cfg.MapFrom(s => s.Tags.Select(di => new EventTagSettingDto
            {
                Tag = di.Key,
                ColorStyle = di.Value,
            })));

        CreateMap<ProjectDashboard, ProjectDashboardDto>();
    }
}