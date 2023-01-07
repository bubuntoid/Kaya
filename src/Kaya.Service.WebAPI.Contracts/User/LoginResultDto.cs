using Kaya.Service.WebAPI.Contracts.Project;

namespace Kaya.Service.WebAPI.Contracts.User;

public class LoginResultDto
{
    public Guid Id { get; set; }
    
    public string Login { get; set; }
    
    public string PrivateKey { get; set; }

    public virtual ICollection<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
}