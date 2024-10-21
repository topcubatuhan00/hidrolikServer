using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Repositories.UserRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.UserRepositories;

public class UserQueryRepository : Repository, IUserQueryRepository
{
    #region Ctor
    public UserQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<User> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [User] WHERE IsActive = 1");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [User] WHERE IsActive = 1 ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Role = reader["Role"].ToString(),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                });
            }
            return new PaginationHelper<User>(totalCount, request.PageSize, request.PageNumber, users);
        }
    }

    public async Task<User> GetById(int id)
    {
        var command = CreateCommand("SELECT * FROM [User] WHERE Id = @id AND IsActive = 1");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Role = reader["Role"].ToString(),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                };
            }
            else
                return null;
        }
    }
}
