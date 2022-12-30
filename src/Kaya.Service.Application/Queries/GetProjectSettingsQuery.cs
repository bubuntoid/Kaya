using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Queries;

public class GetProjectSettingsQuery : IRequest<ProjectSettings>, IProjectAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }

    public class GetProjectSettingsQueryHandler : IRequestHandler<GetProjectSettingsQuery, ProjectSettings>
    {
        private readonly KayaDbContext dbContext;

        public GetProjectSettingsQueryHandler(KayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProjectSettings> Handle(GetProjectSettingsQuery request, CancellationToken cancellationToken)
        {
            var systemEventTags = await dbContext.SystemEventTagSettings.ToListAsync(cancellationToken: cancellationToken);
            var project = await dbContext.Projects
                .Include(s => s.TagSettings)
                .FirstAsync(s => s.PrivateKey == request.PrivateKey, cancellationToken: cancellationToken);

            return new ProjectSettings
            {
                Tags = project.TagSettings
                    .Union(systemEventTags.Select(s => new ProjectEventTagSetting
                    {
                        Style = s.Style,
                        Tag = s.Tag,
                    }))
                    .ToDictionary(s => s.Tag, s => s.Style),
            };
        }
    }
}