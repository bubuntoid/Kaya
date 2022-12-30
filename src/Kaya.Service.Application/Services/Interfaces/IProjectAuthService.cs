using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Errors;

namespace Kaya.Service.Application.Services.Interfaces;

public interface IProjectAuthService
{
    Project Project { get; }
    
    Task<DomainError> AuthorizeAsync(string privateKey);
}