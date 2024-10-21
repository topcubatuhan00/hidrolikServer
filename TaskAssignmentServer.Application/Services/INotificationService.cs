using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.NotificationModels;

namespace Hidrolik.Application.Services;

public interface INotificationService
{
    Task<ResponseDto<List<Notification>>> GetByUserId(int id);
    Task Create(CreateNotificationModel model);
}
