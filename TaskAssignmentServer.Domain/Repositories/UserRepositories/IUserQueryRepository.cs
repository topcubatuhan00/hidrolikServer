using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Domain.Repositories.UserRepositories;

public interface IUserQueryRepository
{
    PaginationHelper<User> GetAll(PaginationRequest request);
    Task<User> GetById(int id);
}
