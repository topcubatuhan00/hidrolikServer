using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.UserModels;
using Hidrolik.Domain.Repositories.UserRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.UserRepositories;

public class UserCommandRepository : Repository, IUserCommandRepository
{
    #region Ctor
    public UserCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public async Task AddAsync(User entity)
    {
        var query = "INSERT INTO [User] " +
            "(" +
            "Name, LastName, UserName, Email, Password, Role," +
            "CreatedDate, CreatorName, UpdatedDate,UpdaterName,DeletedDate,DeleterName,IsActive" +
            ") VALUES" +
            "(@name, @lname, @uname, @mail, @pass, @role," +
            "@ctdate, @crname, @utdate, @urname, @dtdate, @drname, @isactive);" +
            "SELECT SCOPE_IDENTITY();";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@lname", entity.LastName);
        command.Parameters.AddWithValue("@uname", entity.UserName);
        command.Parameters.AddWithValue("@mail", entity.Email);
        command.Parameters.AddWithValue("@pass", entity.Password);
        command.Parameters.AddWithValue("@role", entity.Role);

        command.Parameters.AddWithValue("@ctdate", DateTime.Now);
        command.Parameters.AddWithValue("@crname", entity.CreatorName);
        command.Parameters.AddWithValue("@utdate", DBNull.Value);
        command.Parameters.AddWithValue("@urname", DBNull.Value);
        command.Parameters.AddWithValue("@dtdate", DBNull.Value);
        command.Parameters.AddWithValue("@drname", DBNull.Value);
        command.Parameters.AddWithValue("@isactive", 1);
        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveById(int id)
    {
        var command = CreateCommand("update [User] set IsActive=@active,DeletedDate=@ddate, DeleterName=@dname where Id=@id");
        command.Parameters.AddWithValue("@active", false);
        command.Parameters.AddWithValue("@ddate", DateTime.Now);
        command.Parameters.AddWithValue("@dname", "SERVER");
        command.Parameters.AddWithValue("@id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        var query = "update [User] set Name=@name,LastName=@lname,UserName=@usname,Email=@mail,Password=@pass, UpdatedDate=@udate, UpdaterName=@uname, IsActive=@active where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@lname", entity.LastName);
        command.Parameters.AddWithValue("@usname", entity.UserName);
        command.Parameters.AddWithValue("@mail", entity.Email);
        command.Parameters.AddWithValue("@pass", entity.Password);
        command.Parameters.AddWithValue("@udate", entity.UpdatedDate);
        command.Parameters.AddWithValue("@uname", entity.UpdaterName);
        command.Parameters.AddWithValue("@active", entity.IsActive);
        command.Parameters.AddWithValue("@id", entity.Id);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateRoleAsync(UpdateUserRoleModel model)
    {
        var query = "update [User] set Role=@role, UpdatedDate=@udate, UpdaterName=@udname where UserName=@uname";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@uname", model.UserName);
        command.Parameters.AddWithValue("@role", model.Role);
        command.Parameters.AddWithValue("@udate", DateTime.Now);
        command.Parameters.AddWithValue("@udname", model.UpdaterName);

        await command.ExecuteNonQueryAsync();
    }
}
