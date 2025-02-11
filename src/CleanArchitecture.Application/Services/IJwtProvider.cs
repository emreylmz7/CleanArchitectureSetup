using ClenaArchitecture.Domain.Users;

namespace CleanArchitecture.Application.Services;

public interface IJwtProvider
{
    public Task<string> GenerateJwtToken(AppUser user,CancellationToken cancellationToken = default);
}
