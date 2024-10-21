using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.UserModels;

namespace Hidrolik.Domain.Repositories.UserRepositories;

public interface IUserCommandRepository
{
    Task AddAsync(User entity);
    Task UpdateAsync(User entity);
    Task RemoveById(int id);
    Task UpdateRoleAsync(UpdateUserRoleModel model);
}
