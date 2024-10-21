using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Repositories.AutoReminderRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.AutoReminderRepositories;

public class AutoReminderCommandRepository : Repository, IAutoReminderCommandRepository
{
    #region Ctor
    public AutoReminderCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(AutoReminder autoReminder)
    {
        var query = "INSERT INTO [AutoReminder]" +
            "(CycleTime, MissionId, CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName, IsActive) VALUES" +
            "(@time, @mid ,@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername, @active);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@time", autoReminder.CycleTime);
        command.Parameters.AddWithValue("@mid", autoReminder.MissionId);
        command.Parameters.AddWithValue("@createddate", DateTime.Now);
        command.Parameters.AddWithValue("@creatorname", autoReminder.CreatorName);
        command.Parameters.AddWithValue("@deletedDate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@updatedate", DBNull.Value);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        command.Parameters.AddWithValue("@active", true);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveById(int id)
    {
        var command = CreateCommand("update [AutoReminder] set IsActive=@active,DeletedDate=@ddate, DeleterName=@dname where Id=@id");
        command.Parameters.AddWithValue("@active", false);
        command.Parameters.AddWithValue("@ddate", DateTime.Now);
        command.Parameters.AddWithValue("@dname", "SERVER");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(AutoReminder autoReminder)
    {
        var query = "update [AutoReminder] set CycleTime=@time, MissionId=@mid, UpdatedDate=@udate, UpdaterName=@uname, IsActive=@active where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@time", autoReminder.CycleTime);
        command.Parameters.AddWithValue("@mid", autoReminder.MissionId);
        command.Parameters.AddWithValue("@udate", autoReminder.UpdatedDate);
        command.Parameters.AddWithValue("@uname", autoReminder.UpdaterName);
        command.Parameters.AddWithValue("@active", autoReminder.IsActive);
        command.Parameters.AddWithValue("@id", autoReminder.Id);

        await command.ExecuteNonQueryAsync();
    }
}
