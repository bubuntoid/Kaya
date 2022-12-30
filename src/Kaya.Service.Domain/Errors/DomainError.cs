namespace Kaya.Service.Domain.Errors;

public abstract class DomainError : Exception
{
    public string ErrorCode { get; set; }
    
    public string ErrorMessage { get; set; }
    
    public DomainError(string errorCode, string errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }
}