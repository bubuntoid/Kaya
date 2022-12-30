namespace Kaya.Service.Domain;

/// <summary>
/// Inheritors ignores authorization
/// </summary>
public interface IPrivateKeyRequiredRequest
{
    string PrivateKey { get; set; }
}