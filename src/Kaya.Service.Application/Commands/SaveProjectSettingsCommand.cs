using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Models;
using Kaya.Service.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Commands;

public class SaveProjectSettingsCommand : IRequest<ProjectSettings>, IProjectAuthServiceRequiredRequest
{
    public IDictionary<string, string> EventTags { get; set; }
    public string PrivateKey { get; set; }

    public class SaveProjectSettingsCommandHandler : IRequestHandler<SaveProjectSettingsCommand, ProjectSettings>
    {
        private readonly KayaDbContext dbContext;
        private readonly IMediator mediator;

        public SaveProjectSettingsCommandHandler(KayaDbContext dbContext, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.mediator = mediator;
        }
        
        public async Task<ProjectSettings> Handle(SaveProjectSettingsCommand request, CancellationToken cancellationToken)
        {
            var project = await dbContext.Projects
                .Include(s => s.TagSettings)
                .FirstAsync(s => s.PrivateKey == request.PrivateKey, cancellationToken: cancellationToken);
            
            var systemEventTags = await dbContext.SystemEventTagSettings.ToListAsync(cancellationToken: cancellationToken);

            request.EventTags = request.EventTags.Where(s => systemEventTags.Any(set => set.Tag == s.Key)).ToDictionary(s => s.Key, s => s.Value);
            
            project.TagSettings.Clear();
            foreach (var item in request.EventTags)
            {
                project.TagSettings.Add(new ProjectEventTagSetting
                {
                    Tag = item.Key,
                    Style = item.Value,
                });
            }

            return await mediator.Send(new GetProjectSettingsQuery(), cancellationToken);
        }
    }
}