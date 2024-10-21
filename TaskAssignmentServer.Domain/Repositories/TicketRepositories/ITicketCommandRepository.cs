using Hidrolik.Domain.Entities;

namespace Hidrolik.Domain.Repositories.TicketRepositories;

public interface ITicketCommandRepository
{
    Task AddAsync(Ticket entity);
    Task UpdateAsync(Ticket entity);
    Task RemoveById(int id);
}
