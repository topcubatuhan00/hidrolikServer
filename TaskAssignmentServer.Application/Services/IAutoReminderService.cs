using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.AutoReminder;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Application.Services;

public interface IAutoReminderService
{
    Task<ResponseDto<AutoReminder>> GetById(int id);
    Task<ResponseDto<PaginationHelper<AutoReminder>>> GetAll(PaginationRequest request);
    Task Create(CreateReminderModel model);
    Task Update(UpdateReminderModel model);
    Task Remove(int id);
}
