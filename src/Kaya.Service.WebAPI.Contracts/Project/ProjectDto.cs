namespace Kaya.Service.WebAPI.Contracts.Project;

public class ProjectDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string PrivateKey { get; set; }
    
    public DateTime CreatedDate { get; set; }
}