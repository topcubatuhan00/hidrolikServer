using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Repositories.TicketRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.TicketRepositories;

public class TicketQueryRepository : Repository, ITicketQueryRepository
{
    #region Ctor
    public TicketQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<Ticket> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Tickets]");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Tickets] ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Ticket> tickets = new List<Ticket>();
            while (reader.Read())
            {
                tickets.Add(new Ticket
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                });
            }
            return new PaginationHelper<Ticket>(totalCount, request.PageSize, request.PageNumber, tickets);
        }
    }

    public async Task<Ticket> GetById(int id)
    {
        var command = CreateCommand("SELECT * FROM [Tickets] WHERE Id = @id");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Ticket
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                };
            }
            else
                return null;
        }
    }
}
