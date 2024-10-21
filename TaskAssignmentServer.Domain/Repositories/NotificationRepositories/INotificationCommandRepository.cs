using Hidrolik.Domain.Models.NotificationModels;

namespace Hidrolik.Domain.Repositories.NotificationRepositories;

public interface INotificationCommandRepository
{
    Task CreateTaskAsync(CreateNotificationModel model);
}
