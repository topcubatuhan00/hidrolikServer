using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.TicketModels;

namespace Hidrolik.Application.Services;

public interface ITicketService
{
    Task<ResponseDto<Ticket>> GetById(int id);
    Task<ResponseDto<PaginationHelper<Ticket>>> GetAll(PaginationRequest request);
    Task Create(CreateTicketModel model);
    Task Update(UpdateTicketModel model);
    Task Remove(int id);
}
