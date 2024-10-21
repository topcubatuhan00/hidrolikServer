using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Repositories.CommentRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.CommentRepositories;

public class CommentCommandRepository : Repository, ICommentCommandRepository
{
    #region Ctor
    public CommentCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(Comment entity)
    {
        var query = "INSERT INTO [Comment]" +
                    "(Title,Content,UserId, MissionId, FilePathName,CreatedDate,CreatorName,DeletedDate,DeleterName,UpdatedDate,UpdaterName, IsActive) VALUES" +
                    "(@title, @content, @uid, @mid, @fpath ,@createddate,@creatorname,@deletedDate,@deletername,@updatedate,@updatername, @active);" +
                    "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@title", entity.Title);
        command.Parameters.AddWithValue("@content", entity.Content);
        command.Parameters.AddWithValue("@uid", entity.UserId);
        command.Parameters.AddWithValue("@mid", entity.MissionId);
        command.Parameters.AddWithValue("@fpath", entity.FilePathName);
        command.Parameters.AddWithValue("@createddate", DateTime.Now);
        command.Parameters.AddWithValue("@creatorname", entity.CreatorName);
        command.Parameters.AddWithValue("@deletedDate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@updatedate", DBNull.Value);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        command.Parameters.AddWithValue("@active", true);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveById(int id)
    {
        var command = CreateCommand("update [Comment] set IsActive=@active,DeletedDate=@ddate, DeleterName=@dname where Id=@id");
        command.Parameters.AddWithValue("@active", false);
        command.Parameters.AddWithValue("@ddate", DateTime.Now);
        command.Parameters.AddWithValue("@dname", "SERVER");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Comment entity)
    {
        var query = "update [Comment] set Title=@title, Content=@content, UpdatedDate=@udate, UpdaterName=@uname, IsActive=@active where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@title", entity.Title);
        command.Parameters.AddWithValue("@content", entity.Content);
        command.Parameters.AddWithValue("@udate", entity.UpdatedDate);
        command.Parameters.AddWithValue("@uname", entity.UpdaterName);
        command.Parameters.AddWithValue("@active", entity.IsActive);
        command.Parameters.AddWithValue("@id", entity.Id);

        await command.ExecuteNonQueryAsync();
    }
}
