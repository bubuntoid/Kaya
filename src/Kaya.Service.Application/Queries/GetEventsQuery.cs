using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Queries;

public class GetEventsQuery : IRequest<IReadOnlyCollection<Event>>, IProjectAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }
    
    public StringPair Header { get; set; }
    public string Tag { get; set; }
    
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    
    public int Offset { get; set; }
    public int Limit { get; set; }
    
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IReadOnlyCollection<Event>>
    {
        private readonly KayaDbContext dbContext;

        public GetEventsQueryHandler(KayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<IReadOnlyCollection<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var query = dbContext.Events
                .Include(s => s.Content)
                .Include(s => s.Headers)
                .Where(s => s.Project.PrivateKey == request.PrivateKey);

            if (request.Header is { Value: { }, Header: { } })
                query = query.Where(s => s.Headers.Any(h => h.Key == request.Header.Header && h.Value == request.Header.Value));

            if (request.From.HasValue)
                query = query.Where(s => s.Date >= request.From);

            if (request.To.HasValue)
                query = query.Where(s => s.Date <= request.To);

            if (string.IsNullOrWhiteSpace(request.Tag) == false)
                query = query.Where(s => s.Tags.Any(tag => tag.Tag == request.Tag));

            if (request.Offset != default)
                query = query.Skip(request.Offset);

            if (request.Limit != default)
                query = query.Take(request.Limit);
            
            return await query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}