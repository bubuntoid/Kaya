using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Errors;
using Kaya.Service.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Services;

public class ProjectAuthService : IProjectAuthService
{
    private readonly KayaDbContext dbContext;
    
    public Project Project { get; private set; }
    
    public ProjectAuthService(KayaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<DomainError> AuthorizeAsync(string privateKey)
    {
        Project = await dbContext.Projects.FirstOrDefaultAsync(s => s.PrivateKey == privateKey);
        return Project == null ? new AccessDeniedError() : null;
    }
}
