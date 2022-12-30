using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Errors;
using Kaya.Service.Application.Services.Interfaces;
using MediatR;

namespace Kaya.Service.Application.Commands;

public class AddEventCommand : IRequest<DomainError>, IProjectAuthServiceRequiredRequest
{
    public string Message { get; set; }
    public string Content { get; set; }
    public string PrivateKey { get; set; }
    public ICollection<string> Tags { get; set; }
    public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, DomainError>
    {
        private readonly KayaDbContext dbContext;
        private readonly IProjectAuthService authService;

        public AddEventCommandHandler(KayaDbContext dbContext, IProjectAuthService authService)
        {
            this.dbContext = dbContext;
            this.authService = authService;
        }
    
        public async Task<DomainError> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            await dbContext.Events.AddAsync(new Event
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                ProjectId = authService.Project.Id,
                
                Tags = request.Tags,
                Message = request.Message,
                Content = new EventContent
                {
                    Content = request.Content, 
                },
                Headers = request.Headers.Select(tag => new EventHeader
                {
                    Key = tag.Key,
                    Value = tag.Value,
                }).ToList(),
            }, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);
            
            // todo: send websocket

            return null;
        }
    }
}