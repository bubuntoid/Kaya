using Kaya.Service.Domain;
using Kaya.Service.Domain.Models.Common;

namespace Kaya.Service.WebAPI.Contracts.Project;

public class GetEventsRequestDto : IProjectAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }
    
    public StringPair Header { get; set; }
    public string Tag { get; set; }
    
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    
    public int Offset { get; set; }
    public int Limit { get; set; }
}