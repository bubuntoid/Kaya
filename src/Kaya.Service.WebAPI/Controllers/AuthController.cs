using Autofac;
using AutoMapper;
using Kaya.Service.Application.Commands;
using Kaya.Service.Application.Services.Interfaces;
using Kaya.Service.WebAPI.Attributes;
using Kaya.Service.WebAPI.Contracts;
using Kaya.Service.WebAPI.Contracts.User;
using Kaya.Service.WebAPI.Settings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kaya.Service.WebAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly SystemSettings systemSettings;

    public AuthController(IAuthService authService, IMediator mediator, IMapper mapper, SystemSettings systemSettings)
    {
        this.authService = authService;
        this.mediator = mediator;
        this.mapper = mapper;
        this.systemSettings = systemSettings;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var error = await authService.AuthorizeAsync(dto.Login, dto.Password);

        return error == null 
            ? Ok(mapper.Map<LoginResultDto>(authService.User))
            : Unauthorized();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (systemSettings.EnableRegistration == false)
            return BadRequest("Registration disabled");
        
        await mediator.Send(new SaveUserCommand
        {
            Id = null,
            Name = dto.Name,
            Login = dto.Login,
            Password = dto.Password,
            NewPrivateKey = Guid.NewGuid().ToString(),
        });

        var error = await authService.AuthorizeAsync(dto.Login, dto.Password);
        return error == null 
            ? Ok(mapper.Map<LoginResultDto>(authService.User))
            : Unauthorized();
    }

    [AuthFilter(IsReusable = false)]
    [HttpPost("check")]
    public IActionResult CheckAccess(PrivateKeyOnlyRequestDto _)
    {
        return Ok(mapper.Map<LoginResultDto>(authService.User));
    }
}