using Hangfire;
using Hangfire.Common;
using MediatR;
using Newtonsoft.Json;

namespace Kaya.Service.WebAPI.Extensions;

public static class HangfireExtensions
{
    public static void UseMediatR(this IGlobalConfiguration config, IMediator mediator)
    {
        config.UseActivator(new MediatRJobActivator(mediator));

        GlobalConfiguration.Configuration.UseSerializerSettings(new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
        });
    }
}