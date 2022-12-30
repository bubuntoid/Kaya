using Autofac;
using Kaya.Service.Application;
using Kaya.Service.Application.Services.Interfaces;
using Kaya.Service.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kaya.Service.WebAPI.Filters;

public class AuthFilter : IAsyncActionFilter
{
    private readonly ILifetimeScope scope;

    public AuthFilter(ILifetimeScope scope)
    {
        this.scope = scope;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.Count != 1)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var arg = context.ActionArguments.FirstOrDefault();
        var isAuthServiceRequest = arg.Value is IAuthServiceRequiredRequest; 
        var isProjectAuthServiceRequest = arg.Value is IProjectAuthServiceRequiredRequest; 
        
        if (isAuthServiceRequest == false && isProjectAuthServiceRequest == false)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var privateKey = ((IPrivateKeyRequiredRequest)arg.Value!).PrivateKey;
        var error = isAuthServiceRequest
            ? await scope.Resolve<IAuthService>().AuthorizeAsync(privateKey)
            : await scope.Resolve<IProjectAuthService>().AuthorizeAsync(privateKey);

        if (error != null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}