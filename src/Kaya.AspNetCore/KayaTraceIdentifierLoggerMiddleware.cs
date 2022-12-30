using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Kaya.AspNetCore;

public class KayaTraceIdentifierLoggerMiddleware : IMiddleware
{
    private const string HeaderName = "TraceIdentifier";

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var kayaContext = context.RequestServices.GetRequiredService<IKayaContext>();
        kayaContext.AddHeader(HeaderName, context.TraceIdentifier);
        return next(context);
    }
}