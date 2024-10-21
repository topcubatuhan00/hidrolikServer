using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Repositories.AutoReminderRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.AutoReminderRepositories;

public class AutoReminderQueryepository : Repository, IAutoReminderQueryRepository
{
    #region Ctor
    public AutoReminderQueryepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }

    #endregion
    public PaginationHelper<AutoReminder> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [AutoReminder] WHERE IsActive = 1");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [AutoReminder] WHERE IsActive = 1 ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<AutoReminder> reminders = new List<AutoReminder>();
            while (reader.Read())
            {
                reminders.Add(new AutoReminder
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CycleTime = Convert.ToDateTime(reader["CycleTime"]),
                    MissionId = Convert.ToInt32(reader["MissionId"]),
                    CreatorName = reader["CreatorName"].ToString(),
                });
            }
            return new PaginationHelper<AutoReminder>(totalCount, request.PageSize, request.PageNumber, reminders);
        }

    }

    public async Task<AutoReminder> GetById(int id)
    {
        var command = CreateCommand("SELECT * FROM [AutoReminder] WHERE Id = @id AND IsActive = 1");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new AutoReminder
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CycleTime = Convert.ToDateTime(reader["CycleTime"]),
                    MissionId = Convert.ToInt32(reader["MissionId"]),
                    CreatorName = reader["CreatorName"].ToString()
                };
            }
            else
                return null;
        }

    }
}
