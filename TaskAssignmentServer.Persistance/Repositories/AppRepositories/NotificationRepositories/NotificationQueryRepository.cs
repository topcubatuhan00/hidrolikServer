using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Repositories.NotificationRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.NotificationRepositories;

public class NotificationQueryRepository : Repository, INotificationQueryRepository
{
    #region Ctor
    public NotificationQueryRepository
    (
        SqlConnection context,
        SqlTransaction transaction
    )
    {
        this._context = context;
        this._transaction = transaction;
    }

    public async Task<List<Notification>> GetByUserId(int id)
    {
        var command = CreateCommand("SELECT TOP 6 * FROM [Notification] WHERE UserId = @id ORDER BY Id DESC");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = await command.ExecuteReaderAsync())
        {
            List<Notification> notifications = new List<Notification>();
            while (await reader.ReadAsync())
            {
                notifications.Add(new Notification
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Content = reader["Content"].ToString(),
                    UserId = Convert.ToInt32(reader["UserId"])
                });
            }
            return notifications;
        }
    }
    #endregion
}
