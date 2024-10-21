using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.MissionModels;

namespace Hidrolik.Application.Services;

public interface IMissionService
{
    Task<ResponseDto<Mission>> GetById(int id);
    Task<ResponseDto<PaginationHelper<Mission>>> GetByUserId(GetMissionModel request);
    Task<ResponseDto<Mission>> GetByName(string name);
    Task<ResponseDto<PaginationHelper<Mission>>> GetAll(PaginationRequest request);
    Task Create(CreateMissionModel model);
    Task Update(UpdateMissionModel model);
    Task Remove(int id);
    Task<ResponseSalesDto> GetByUserIdForChart(int id);
}
