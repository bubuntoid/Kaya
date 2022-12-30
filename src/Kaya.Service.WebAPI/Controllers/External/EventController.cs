using Kaya.Service.Application.Commands;
using Kaya.Service.WebAPI.Contracts.External;
using Kaya.Service.WebAPI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kaya.Service.WebAPI.Controllers.External;

[ApiController]
[Route("api/event")]
public class EventController : ControllerBase
{
    private readonly IMediator mediator;

    public EventController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("log")]
    public IActionResult Log(EventDto dto)
    {
        mediator.Enqueue(new AddEventCommand
        {
            Message = dto.Message,
            Content = dto.Content,
            PrivateKey = dto.PrivateKey,
            Headers = dto.Headers,
            Tags = dto.Tags,
        });
        
        return Ok();
    }
}