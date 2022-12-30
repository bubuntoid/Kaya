using Kaya.Service.Application.Queries;
using Kaya.Service.WebAPI.Attributes;
using Kaya.Service.WebAPI.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kaya.Service.WebAPI.Controllers;

[ApiController]
[Route("api/export")]
[AuthFilter(IsReusable = false)]
public class ExportController : ControllerBase
{
    private readonly IMediator mediator;

    public ExportController(IMediator mediator)
    {
        this.mediator = mediator;
    }  

    [HttpPost("logs/plain")]
    public async Task<IActionResult> ExportAsPlainText(PrivateKeyOnlyRequestDto dto)
    {
        var response = await mediator.Send(new ExportAsPlainTextQuery
        {
            PrivateKey = dto.PrivateKey,
        });

        return Ok(response);
    }
}