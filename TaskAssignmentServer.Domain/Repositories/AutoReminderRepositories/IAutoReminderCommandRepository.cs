using Hidrolik.Domain.Entities;

namespace Hidrolik.Domain.Repositories.AutoReminderRepositories;

public interface IAutoReminderCommandRepository
{
    Task AddAsync(AutoReminder autoReminder);
    Task UpdateAsync(AutoReminder autoReminder);
    Task RemoveById(int id);
}
