using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.MissionModels;
using Hidrolik.Domain.Repositories.MissionRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.MissionRepositories;

public class MissionCommandRepository : Repository, IMissionCommandRepository
{
    #region Ctor
    public MissionCommandRepository
    (
        SqlConnection context,
        SqlTransaction transaction
    )
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task CreateTaskAsync(CreateMissionModel model)
    {
        var query = "INSERT INTO [Mission]" +
            "(Name, Descripton,Status,Priority,EstimatedEndDate,UserId,Ticket, CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName, IsActive) VALUES" +
            "(@name, @desc, @status, @priority, @estdate, @uid, @ticket, @createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername, @active);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@desc", model.Description);
        command.Parameters.AddWithValue("@status", model.Status);
        command.Parameters.AddWithValue("@priority", model.Priority);
        command.Parameters.AddWithValue("@estdate", model.EstimatedEndDate);
        command.Parameters.AddWithValue("@uid", model.UserId);
        command.Parameters.AddWithValue("@ticket", model.Ticket);
        command.Parameters.AddWithValue("@createddate", DateTime.Now);
        command.Parameters.AddWithValue("@creatorname", model.CreatorName);
        command.Parameters.AddWithValue("@deletedDate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@updatedate", DBNull.Value);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        command.Parameters.AddWithValue("@active", true);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveTaskByIdAsync(int taskId)
    {
        var command = CreateCommand("update [Mission] set IsActive=@active,DeletedDate=@ddate, DeleterName=@dname where Id=@id");
        command.Parameters.AddWithValue("@active", false);
        command.Parameters.AddWithValue("@ddate", DateTime.Now);
        command.Parameters.AddWithValue("@dname", "SERVER");
        command.Parameters.AddWithValue("@id", taskId);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateTaskAsync(UpdateMissionModel model)
    {
        var query = "update [Mission] set Name=@name, Descripton=@desc, Status=@status, Priority=@priority,EstimatedEndDate=@est,UserId=@uid, Ticket=@ticket," +
            "UpdatedDate=@udate, UpdaterName=@uname, IsActive=@active where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", model.Name);
        command.Parameters.AddWithValue("@desc", model.Description);
        command.Parameters.AddWithValue("@status", model.Status);
        command.Parameters.AddWithValue("@priority", model.Priority);
        command.Parameters.AddWithValue("@est", model.EstimatedEndDate);
        command.Parameters.AddWithValue("@uid", model.UserId);
        command.Parameters.AddWithValue("@ticket", model.Ticket);

        command.Parameters.AddWithValue("@udate", DateTime.Now);
        command.Parameters.AddWithValue("@uname", model.UpdaterName);
        command.Parameters.AddWithValue("@active", model.IsActive);
        command.Parameters.AddWithValue("@id", model.Id);

        await command.ExecuteNonQueryAsync();
    }
    #endregion

}
