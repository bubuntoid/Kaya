using Autofac;
using AutoMapper;
using Kaya.Service.Application.Commands;
using Kaya.Service.Application.Services.Interfaces;
using Kaya.Service.WebAPI.Attributes;
using Kaya.Service.WebAPI.Contracts;
using Kaya.Service.WebAPI.Contracts.User;
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

    public AuthController(IAuthService authService, IMediator mediator, IMapper mapper)
    {
        this.authService = authService;
        this.mediator = mediator;
        this.mapper = mapper;
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
    public async Task<IActionResult> Register(LoginDto dto)
    {
        var response = await mediator.Send(new SaveUserCommand
        {
            Id = null,
            Login = dto.Login,
            Password = dto.Password,
            NewPrivateKey = Guid.NewGuid().ToString(),
        });

        return Ok(response);
    }

    [AuthFilter(IsReusable = false)]
    [HttpPost("check")]
    public IActionResult CheckAccess(PrivateKeyOnlyRequestDto _)
    {
        return Ok(mapper.Map<LoginResultDto>(authService.User));
    }
}