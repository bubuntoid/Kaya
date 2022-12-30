using MediatR;

namespace Kaya.Service.WebAPI.Extensions;

public class HangfireMediator
{
    private readonly IMediator mediator;

    public HangfireMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task SendCommand(object request)
    {
        try
        {
            await mediator.Send(request);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}