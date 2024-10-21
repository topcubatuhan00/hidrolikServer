using Hidrolik.Domain.Entities;

namespace Hidrolik.Domain.Repositories.AuthRepositories;

public interface IAuthQueryRepository
{
    Task<User> GetByUserName(string userName);
}
