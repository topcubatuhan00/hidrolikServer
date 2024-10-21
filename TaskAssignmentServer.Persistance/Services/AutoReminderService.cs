using AutoMapper;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.AutoReminder;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.UnitOfWork;

namespace Hidrolik.Persistance.Services;

public class AutoReminderService : IAutoReminderService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public AutoReminderService
    (
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    #endregion

    #region Methods
    public async Task Create(CreateReminderModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<AutoReminder>(model);
            await context.Repositories.autoReminderCommandRepository.AddAsync(entity);
            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<AutoReminder>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.autoReminderQueryRepository.GetAll(request);
            var paginationHelper = new PaginationHelper<AutoReminder>(result.TotalCount, request.PageSize, request.PageNumber,null);
            var reminders = result.Items.Select(item => _mapper.Map<AutoReminder>(item)).ToList();
            paginationHelper.Items = reminders;
            return ResponseDto<PaginationHelper<AutoReminder>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<AutoReminder>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.autoReminderQueryRepository.GetById(id);
            return ResponseDto<AutoReminder>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.autoReminderQueryRepository.GetById(id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.autoReminderCommandRepository.RemoveById(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateReminderModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.autoReminderQueryRepository.GetById(model.Id);
            if (check == null) throw new Exception("Not Found");

            var entity = _mapper.Map<AutoReminder>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = model.UpdaterName;
            await context.Repositories.autoReminderCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
    #endregion
}
