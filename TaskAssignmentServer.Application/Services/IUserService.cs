using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.UserModels;

namespace Hidrolik.Application.Services;

public interface IUserService
{
    Task<ResponseDto<User>> GetById(int id);
    Task<ResponseDto<PaginationHelper<User>>> GetAll(PaginationRequest request);
    Task Create(CreateUserModel model);
    Task Update(UpdateUserModel model);
    Task UpdateRole(UpdateUserRoleModel model);
    Task Remove(int id);
}
