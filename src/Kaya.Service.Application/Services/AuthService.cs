using Kaya.Service.Domain;
using Kaya.Service.Domain.Entities;
using Kaya.Service.Domain.Errors;
using Kaya.Service.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Application.Services;

public class AuthService : IAuthService
{
    private readonly KayaDbContext dbContext;
    
    public User User { get; private set; }
    
    public AuthService(KayaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<DomainError> AuthorizeAsync(string privateKey)
    {
        User = await Query().FirstOrDefaultAsync(s => s.PrivateKey == privateKey);
        return User == null ? new AccessDeniedError() : null;
    }

    public async Task<DomainError> AuthorizeAsync(string login, string password)
    {
        User = await Query().FirstOrDefaultAsync(s => s.Login == login && s.Password == password);
        return User == null ? new AccessDeniedError() : null;
    }

    private IQueryable<User> Query()
    {
        return dbContext.Users.Include(s => s.Projects);
    }
}