using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Domain.Repositories.AutoReminderRepositories;

public interface IAutoReminderQueryRepository
{
    PaginationHelper<AutoReminder> GetAll(PaginationRequest request);
    Task<AutoReminder> GetById(int id);
}
