namespace Kaya.Service.Domain.Errors;

public class AccessDeniedError : DomainError
{
    public AccessDeniedError(string errorMessage = "Access denied") : base("access_denied", errorMessage)
    {
        
    }
}