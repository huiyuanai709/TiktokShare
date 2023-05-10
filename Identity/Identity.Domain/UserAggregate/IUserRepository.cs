using SourceGeneratorPower.Services.Attributes;

namespace Identity.Domain.UserAggregate;

public interface IUserRepository
{
    Task<User?> FindByUserName(string username, CancellationToken cancellationToken = default);
}