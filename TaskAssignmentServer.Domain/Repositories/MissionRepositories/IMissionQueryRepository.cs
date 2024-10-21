using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.MissionModels;

namespace Hidrolik.Domain.Repositories.MissionRepositories;

public interface IMissionQueryRepository
{
    PaginationHelper<Mission> GetAll(PaginationRequest request);
    Task<Mission> GetById(int id);
    Task<Mission> GetByName(string name);
    PaginationHelper<Mission> GetByUserId(GetMissionModel request);
    Task<ResponseSalesDto> GetByUserIdForChart(int id);
}
