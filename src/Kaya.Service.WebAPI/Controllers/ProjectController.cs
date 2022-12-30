using System.Text;
using AutoMapper;
using Kaya.Service.Application.Commands;
using Kaya.Service.Application.Queries;
using Kaya.Service.Application.Services.Interfaces;
using Kaya.Service.WebAPI.Attributes;
using Kaya.Service.WebAPI.Contracts;
using Kaya.Service.WebAPI.Contracts.External;
using Kaya.Service.WebAPI.Contracts.Project;
using Kaya.Service.WebAPI.Contracts.Project.Settings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace Kaya.Service.WebAPI.Controllers;

[ApiController]
[Route("api/project")]
[AuthFilter(IsReusable = false)]
public class ProjectController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly IProjectAuthService authService;

    public ProjectController(IMediator mediator, IMapper mapper, IProjectAuthService authService)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.authService = authService;
    }

    [HttpPost("save")]
    public async Task<IActionResult> SaveProject(ProjectSaveDto dto)
    {
        var response = await mediator.Send(new SaveProjectCommand
        {
            PrivateKey = dto.PrivateKey,
            ProjectId = null,
            Name = dto.Name,
            NewPrivateKey = dto.NewPrivateKey,
        });

        return Ok(response);
    }

    [HttpPost("events/get")]
    public async Task<IActionResult> GetEvents(GetEventsRequestDto dto)
    {
        var response = await mediator.Send(new GetEventsQuery
        {
            PrivateKey = dto.PrivateKey,
            Header = dto.Header,
            Offset = dto.Offset,
            Limit = dto.Limit,
            From = dto.From,
            To = dto.To,
            Tag = dto.Tag,
        });

        return Ok(response.Select(s => mapper.Map<EventDto>(s)));
    }
    
    [HttpPost("settings/get")]
    public async Task<IActionResult> GetProjectSettings(ProjectPrivateKeyOnlyRequestDto dto)
    {
        var response = await mediator.Send(new GetProjectSettingsQuery
        {
            PrivateKey = dto.PrivateKey,
        });

        return Ok(mapper.Map<ProjectSettingsDto>(response));
    }

    [HttpPost("settings/save")]
    public async Task<IActionResult> SaveProjectSettings(ProjectSettingsSaveDto dto)
    {
        var response = await mediator.Send(new SaveProjectSettingsCommand
        {
            PrivateKey = dto.PrivateKey,
            EventTags = dto.EventTags.ToDictionary(s => s.Tag, s => s.ColorStyle)
        });

        return Ok(mapper.Map<ProjectSettingsDto>(response));
    }

    [HttpPost("dashboard")]
    public async Task<IActionResult> GetDashboard(PrivateKeyOnlyRequestDto dto)
    {
        return null;
    }

    [HttpPost("check")]
    public IActionResult CheckAccess(ProjectPrivateKeyOnlyRequestDto _)
    {
        return Ok(mapper.Map<ProjectDto>(authService.Project));
    }
}