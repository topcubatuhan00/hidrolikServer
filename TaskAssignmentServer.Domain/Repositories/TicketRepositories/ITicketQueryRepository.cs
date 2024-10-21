using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Domain.Repositories.TicketRepositories;

public interface ITicketQueryRepository
{
    PaginationHelper<Ticket> GetAll(PaginationRequest request);
    Task<Ticket> GetById(int id);
}
