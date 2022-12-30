using System.Text;
using Kaya.Service.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Queries;

public class ExportAsPlainTextQuery : IRequest<string>, IProjectAuthServiceRequiredRequest
{
    public string PrivateKey { get; set; }
    
    public class ExportAsPlainTextQueryHandler : IRequestHandler<ExportAsPlainTextQuery, string>
    {
        private readonly KayaDbContext dbContext;

        public ExportAsPlainTextQueryHandler(KayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<string> Handle(ExportAsPlainTextQuery request, CancellationToken cancellationToken)
        {
            var events = await dbContext.Events
                .Include(s => s.Content)
                .Include(s => s.Headers)
                .Where(s => s.Project.PrivateKey == request.PrivateKey)
                .OrderByDescending(s => s.Date)
                .ToListAsync(cancellationToken: cancellationToken);

            var stringBuilder = new StringBuilder();

            foreach (var item in events)
            {
                stringBuilder.Append($"{item.Date} ");
                stringBuilder.Append($"[{string.Join(", ", item.Tags.Select(s => s.ToUpper()))}] ");
                stringBuilder.AppendLine($"({string.Join(", ", item.Headers.Select(s => s.Key.ToUpper() + ": " + s.Value))})");
                stringBuilder.AppendLine(item.Content.Content);
            }

            return stringBuilder.ToString();
        }
    }
}