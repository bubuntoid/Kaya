using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Models.Dashboard;
using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Kaya.Service.Application.Queries;

public class GetProjectDashboardQuery : IRequest<ProjectDashboard>, IProjectAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }
    
    public class GetProjectDashboardQueryHandler : IRequestHandler<GetProjectDashboardQuery, ProjectDashboard>
    {
        private readonly IMediator mediator;
        private readonly KayaDbContext dbContext;

        public GetProjectDashboardQueryHandler(IMediator mediator, KayaDbContext dbContext)
        {
            this.mediator = mediator;
            this.dbContext = dbContext;
        }

        public async Task<ProjectDashboard> Handle(GetProjectDashboardQuery request, CancellationToken cancellationToken)
        {
            var systemTags = await dbContext.SystemEventTagSettings.ToListAsync(cancellationToken: cancellationToken);
            var events = await mediator.Send(new GetEventsQuery
            {
                From = DateTime.Today,
                To = DateTime.Today.AddDays(1),
                PrivateKey = request.PrivateKey,
            }, cancellationToken);

            var dashboard = new ProjectDashboard();

            var tags = events.SelectMany(s => s.Tags.Select(tag => tag.Tag)).Concat(systemTags.Select(s => s.Tag)).Distinct().ToList();
            foreach (var tag in tags)
                dashboard.Tags.Add(tag, new List<DateTime>());

            var headers = events.SelectMany(s => s.Headers.Select(h => h.Key)).Distinct().ToList();
            foreach (var header in headers)
                dashboard.Headers.Add(header, new List<DateTime>());

            var headerValues = events.SelectMany(s => s.Headers.Select(h => h.Value)).Distinct().ToList();
            foreach (var header in headerValues)
                dashboard.HeaderValues.Add(header, new List<DateTime>());

            foreach (var item in events)
            {
                foreach (var tag in item.Tags)
                    dashboard.Tags[tag.Tag].Add(item.Date);

                foreach (var header in item.Headers)
                {
                    dashboard.Headers[header.Key].Add(item.Date);
                    dashboard.HeaderValues[header.Value].Add(item.Date);
                }
            }

            return dashboard;
        }
    }
}