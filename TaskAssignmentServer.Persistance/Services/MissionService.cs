using AutoMapper;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.MissionModels;
using Hidrolik.Domain.UnitOfWork;
using Hidrolik.Domain.Models.NotificationModels;
using Azure.Core;

namespace Hidrolik.Persistance.Services;

public class MissionService : IMissionService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public MissionService
    (
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    #endregion
    public async Task Create(CreateMissionModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            await context.Repositories.missionCommandRepository.CreateTaskAsync(model);
            string notificationContent = $"{model.Name} | {DateTime.Now}";
            await context.Repositories.notificationCommandRepository.CreateTaskAsync(new CreateNotificationModel { UserId = model.UserId, Content=notificationContent});
            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<Mission>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.missionQueryRepository.GetAll(request);
            var paginationHelper = new PaginationHelper<Mission>(result.TotalCount, request.PageSize, request.PageNumber, null);
            var items = result.Items.Select(item => _mapper.Map<Mission>(item)).ToList();
            paginationHelper.Items = items;
            return ResponseDto<PaginationHelper<Mission>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Mission>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.missionQueryRepository.GetById(id);
            return ResponseDto<Mission>.Success(result, 200);
        }
    }

    public async Task<ResponseDto<Mission>> GetByName(string name)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.missionQueryRepository.GetByName(name);
            return ResponseDto<Mission>.Success(result, 200);
        }
    }

    public async Task<ResponseDto<PaginationHelper<Mission>>> GetByUserId(GetMissionModel request)
    {
        using (var context = _unitOfWork.Create())
        {
            //var result = await context.Repositories.missionQueryRepository.GetByUserId(request.UserId);
            //return ResponseDto<List<Mission>>.Success(result, 200);
            var result = context.Repositories.missionQueryRepository.GetByUserId(request);
            var paginationHelper = new PaginationHelper<Mission>(result.TotalCount, request.PageSize, request.PageNumber, null);
            var items = result.Items.Select(item => _mapper.Map<Mission>(item)).ToList();
            paginationHelper.Items = items;
            return ResponseDto<PaginationHelper<Mission>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseSalesDto> GetByUserIdForChart(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.missionQueryRepository.GetByUserIdForChart(id);
            return result;
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.missionQueryRepository.GetById(id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.missionCommandRepository.RemoveTaskByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateMissionModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.missionQueryRepository.GetById(model.Id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.missionCommandRepository.UpdateTaskAsync(model);
            context.SaveChanges();
        }
    }
}
