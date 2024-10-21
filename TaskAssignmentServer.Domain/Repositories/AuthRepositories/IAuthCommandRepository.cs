using Hidrolik.Domain.Models.Auth;

namespace Hidrolik.Domain.Repositories.AuthRepositories;

public interface IAuthCommandRepository
{
    Task<bool> AddAsync(AuthRegisterModel user);
}
