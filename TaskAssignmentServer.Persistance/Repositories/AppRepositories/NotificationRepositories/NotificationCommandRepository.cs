using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Models.NotificationModels;
using Hidrolik.Domain.Repositories.NotificationRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.NotificationRepositories;

public class NotificationCommandRepository : Repository, INotificationCommandRepository
{
    #region Ctor
    public NotificationCommandRepository
    (
        SqlConnection context,
        SqlTransaction transaction
    )
    {
        this._context = context;
        this._transaction = transaction;
    }

    public async Task CreateTaskAsync(CreateNotificationModel model)
    {
        var query = "INSERT INTO [Notification]" +
            "(Content, UserId) VALUES" +
            "(@content, @uid);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@content", model.Content);
        command.Parameters.AddWithValue("@uid", model.UserId);
        await command.ExecuteNonQueryAsync();
    }
    #endregion
}