using Microsoft.AspNetCore.Mvc.Filters;

namespace Kaya.AspNetCore;

public class KayaExceptionFilter : IAsyncExceptionFilter
{
    private readonly IKayaContext kayaContext;

    public KayaExceptionFilter(IKayaContext kayaContext)
    {
        this.kayaContext = kayaContext;
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        var ex = context.Exception;
        kayaContext.LogError(ex.Message, ex);
        return Task.CompletedTask;
    }
}