﻿using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Repositories.AuthRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.AuthRepositories;

public class AuthQueryRepository : Repository, IAuthQueryRepository
{
    #region Ctor
    public AuthQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task<User> GetByUserName(string userName)
    {
        var command = CreateCommand("SELECT * FROM [User] WHERE UserName=@username");
        command.Parameters.AddWithValue("@username", userName);
        using (var reader = await command.ExecuteReaderAsync())
        {
            if (reader.Read())
            {
                var user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Email = reader["Email"].ToString(),
                    Role = reader["Role"].ToString(),
                    Name = reader["Name"].ToString(),
                    LastName = reader["LastName"].ToString(),
                };

                return user;
            }
        }
        return null;
    }
    #endregion
}
