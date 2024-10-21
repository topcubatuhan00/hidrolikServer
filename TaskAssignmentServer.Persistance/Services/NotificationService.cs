using AutoMapper;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.NotificationModels;
using Hidrolik.Domain.UnitOfWork;

namespace Hidrolik.Persistance.Services;

public class NotificationService : INotificationService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public NotificationService
    (
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    #endregion
    public async Task Create(CreateNotificationModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            await context.Repositories.notificationCommandRepository.CreateTaskAsync(model);
            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<List<Notification>>> GetByUserId(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var data = await context.Repositories.notificationQueryRepository.GetByUserId(id);
            return ResponseDto<List<Notification>>.Success(data, 200);
        }
    }
}
