using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Errors;

namespace Kaya.Service.Application.Services.Interfaces;

public interface IAuthService
{
    User User { get; }
    
    Task<DomainError> AuthorizeAsync(string privateKey);
    
    Task<DomainError> AuthorizeAsync(string login, string password);
}