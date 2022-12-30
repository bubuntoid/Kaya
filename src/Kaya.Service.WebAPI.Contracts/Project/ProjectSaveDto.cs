namespace Kaya.Service.WebAPI.Contracts.Project;

public class ProjectSaveDto
{
    public Guid? Id { get; set; }
    
    public string Name { get; set; }
    
    public string PrivateKey { get; set; }
    
    public string NewPrivateKey { get; set; }
}