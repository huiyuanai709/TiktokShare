using Identity.Domain.UserAggregate;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using SourceGeneratorPower.Services.Attributes;

namespace Identity.Infrastructure.Repositories;

[ScopedService]
public class UserRepository : IUserRepository
{
    private readonly TiktokShareDbContext _dbContext;

    public UserRepository(TiktokShareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> FindByUserName(string username, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.Where(x => x.Username == username)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}