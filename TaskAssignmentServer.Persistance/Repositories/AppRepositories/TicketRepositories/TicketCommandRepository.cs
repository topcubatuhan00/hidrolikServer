using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Repositories.TicketRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.TicketRepositories;

public class TicketCommandRepository : Repository, ITicketCommandRepository
{
    #region Ctor
    public TicketCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(Ticket entity)
    {
        var query = "INSERT INTO [Tickets]" +
            "(Name) VALUES" +
            "(@name);";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", entity.Name);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveById(int id)
    {
        // this function will be removed.
        var command = CreateCommand("DELETE FROM [Tickets] where Id=@id");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Ticket entity)
    {
        var query = "update [Tickets] set Name=@name where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@id", entity.Id);

        await command.ExecuteNonQueryAsync();
    }
}
