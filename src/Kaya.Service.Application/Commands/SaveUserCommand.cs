using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Commands;

public class SaveUserCommand : IRequest<User>
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string NewPrivateKey { get; set; }

    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, User>
    {
        private readonly KayaDbContext dbContext;

        public SaveUserCommandHandler(KayaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<User> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            User user;
            
            if (request.Id.HasValue == false)
            {
                user = new User
                {
                    Id = Guid.NewGuid(),
                };
                
                await dbContext.Users.AddAsync(user, cancellationToken);
            }
            else
            {
                user = await dbContext.Users.FirstAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
            }

            user.Name = request.Name;
            user.Login = request.Login;
            user.Password = request.Password;
            user.PrivateKey = request.NewPrivateKey;

            await dbContext.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}