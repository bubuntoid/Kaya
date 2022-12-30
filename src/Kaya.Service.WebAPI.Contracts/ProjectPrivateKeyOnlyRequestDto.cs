using Kaya.Service.Domain;

namespace Kaya.Service.WebAPI.Contracts;

public class ProjectPrivateKeyOnlyRequestDto : IProjectAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }
}