using Kaya.Service.Domain;

namespace Kaya.Service.WebAPI.Contracts;

public class PrivateKeyOnlyRequestDto : IAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }
}