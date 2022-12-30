using Autofac;
using Kaya.Service.Domain;
using Kaya.Service.Domain.Errors;
using Kaya.Service.Application.Services.Interfaces;
using MediatR;

namespace Kaya.Service.Application.Pipelines;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILifetimeScope scope;

    public AuthorizationBehaviour(ILifetimeScope scope)
    {
        this.scope = scope;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IAuthServiceRequiredRequest userKeyRequest)
        {
            var error = await scope.Resolve<IAuthService>().AuthorizeAsync(userKeyRequest.PrivateKey);
            if (error == null)
            {
                return await next();
            }

            throw error;;
        }
        
        if (request is IProjectAuthServiceRequiredRequest projectKeyRequest)
        {
            var error = await scope.Resolve<IProjectAuthService>().AuthorizeAsync(projectKeyRequest.PrivateKey);
            if (error == null)
            {
                return await next();
            }

            throw error;;
        }
        

        return await next();
    }
}