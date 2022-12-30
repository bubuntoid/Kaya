using Hangfire;
using MediatR;

namespace Kaya.Service.WebAPI.Extensions;

public class MediatRJobActivator : JobActivator
{
    private readonly IMediator mediator;

    public MediatRJobActivator(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public override object ActivateJob(Type type)
    {
        return new HangfireMediator(mediator);
    }
}