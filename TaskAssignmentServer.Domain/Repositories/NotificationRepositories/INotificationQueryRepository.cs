using Hidrolik.Domain.Entities;

namespace Hidrolik.Domain.Repositories.NotificationRepositories;

public interface INotificationQueryRepository
{
    Task<List<Notification>> GetByUserId(int id);
}
