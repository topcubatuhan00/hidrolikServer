using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.CommentModels;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Repositories.CommentRepositories;
using Microsoft.Data.SqlClient;

namespace Hidrolik.Persistance.Repositories.AppRepositories.CommentRepositories;

public class CommentQueryRepository : Repository, ICommentQueryRepository
{
    #region Ctor
    public CommentQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<Comment> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Comment] WHERE IsActive = 1");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Comment] WHERE IsActive = 1 ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Comment> comments = new List<Comment>();
            while (reader.Read())
            {
                comments.Add(new Comment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    MissionId = Convert.ToInt32(reader["MissionId"]),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                });
            }
            return new PaginationHelper<Comment>(totalCount, request.PageSize, request.PageNumber, comments);
        }
    }

    public async Task<Comment> GetById(int id)
    {
        var command = CreateCommand("SELECT * FROM [Comment] WHERE Id=@id AND IsActive = 1");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Comment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    MissionId = Convert.ToInt32(reader["MissionId"]),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                };
            }
            else
                return null;
        }
    }

    public async Task<List<Comment>> GetByIdUserId(int id)
    {
        var command = CreateCommand(@"
        SELECT * 
        FROM [Comment] c
        INNER JOIN [Mission] m ON c.MissionId = m.Id
        WHERE c.UserId = @uid AND c.IsActive = 1 AND m.IsActive = 1
        ORDER BY c.Id DESC");

        command.Parameters.AddWithValue("@uid", id);

        using (var reader = command.ExecuteReader())
        {
            List<Comment> comments = new List<Comment>();
            while (reader.Read())
            {
                comments.Add(new Comment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    MissionId = Convert.ToInt32(reader["MissionId"]),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                });
            }
            return comments;
        }
    }


    public async Task<List<Comment>> GetComments(GetCommentModel model)
    {
        var command = CreateCommand("SELECT * FROM [Comment] WHERE MissionId=@mid AND IsActive = 1");
        command.Parameters.AddWithValue("@mid", model.MissionId);

        using (var reader = command.ExecuteReader())
        {
            List<Comment> comments = new List<Comment>();
            while (reader.Read())
            {
                comments.Add(new Comment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    MissionId = Convert.ToInt32(reader["MissionId"]),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                });
            }
            return comments;
        }
    }
}
