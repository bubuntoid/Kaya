using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Commands;

public class SaveProjectCommand : IRequest<Project>, IAuthServiceRequiredRequest
{
    public Guid? ProjectId { get; set; }
    public string Name { get; set; }
    public string NewPrivateKey { get; set; }
    public string PrivateKey { get; set; }

    public class AddProjectCommandHandler : IRequestHandler<SaveProjectCommand, Project>
    {
        private readonly IAuthService authService;
        private readonly KayaDbContext dbContext;

        public AddProjectCommandHandler(IAuthService authService, KayaDbContext dbContext)
        {
            this.authService = authService;
            this.dbContext = dbContext;
        }
        
        public async Task<Project> Handle(SaveProjectCommand request, CancellationToken cancellationToken)
        {
            Project project;
            
            if (request.ProjectId.HasValue)
            {
                project = new Project
                {
                    Id = Guid.NewGuid(),
                    UserId = authService.User.Id,
                    CreatedDate = DateTime.UtcNow,
                };
                
                await dbContext.Projects.AddAsync(project, cancellationToken);
            }
            else
            {
                project = await dbContext.Projects.FirstAsync(s => s.Id == request.ProjectId, cancellationToken: cancellationToken);
            }

            project.Name = request.Name;
            project.PrivateKey = request.NewPrivateKey;

            await dbContext.SaveChangesAsync(cancellationToken);
            return project;
        }
    }
}