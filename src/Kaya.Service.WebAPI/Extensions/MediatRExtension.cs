using Hangfire;
using MediatR;

namespace Kaya.Service.WebAPI.Extensions;

public static class MediatRExtension
{
    public static void Enqueue(this IMediator mediator, object request)
    {
        BackgroundJob.Enqueue<HangfireMediator>(m => m.SendCommand(request));
    }
}