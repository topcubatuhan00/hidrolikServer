﻿using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Models.Auth;
using Hidrolik.Domain.Repositories.AuthRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.AuthRepositories;

public class AuthCommandRepository : Repository, IAuthCommandRepository
{
    #region Ctor
    public AuthCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task<bool> AddAsync(AuthRegisterModel user)
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
        command.Parameters.AddWithValue("@name", user.Name);
        command.Parameters.AddWithValue("@lname", user.LastName);
        command.Parameters.AddWithValue("@uname", user.UserName);
        command.Parameters.AddWithValue("@mail", user.Email);
        command.Parameters.AddWithValue("@pass", user.Password);
        command.Parameters.AddWithValue("@role", user.Role);

        command.Parameters.AddWithValue("@ctdate", DateTime.Now);
        command.Parameters.AddWithValue("@crname", user.CreatorName);
        command.Parameters.AddWithValue("@utdate", DBNull.Value);
        command.Parameters.AddWithValue("@urname", DBNull.Value);
        command.Parameters.AddWithValue("@dtdate", DBNull.Value);
        command.Parameters.AddWithValue("@drname", DBNull.Value);
        command.Parameters.AddWithValue("@isactive", 1);
        var res = await command.ExecuteNonQueryAsync();
        if (res > 0) return true;
        return false;
    }
    #endregion
}
