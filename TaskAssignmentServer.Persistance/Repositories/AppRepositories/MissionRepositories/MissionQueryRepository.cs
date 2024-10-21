using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.MissionModels;
using Hidrolik.Domain.Repositories.MissionRepositories;

namespace Hidrolik.Persistance.Repositories.AppRepositories.MissionRepositories;

public class MissionQueryRepository : Repository, IMissionQueryRepository
{
    #region Ctor
    public MissionQueryRepository
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
    public PaginationHelper<Mission> GetAll(PaginationRequest request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Mission] WHERE IsActive = 1");
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Mission] WHERE IsActive = 1 ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        using (var reader = command.ExecuteReader())
        {
            List<Mission> missions = new List<Mission>();
            while (reader.Read())
            {
                missions.Add(new Mission
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Descripton"].ToString(),
                    Status = reader["Status"].ToString(),
                    Priority = reader["Priority"].ToString(),
                    EstimatedEndDate = Convert.ToDateTime(reader["EstimatedEndDate"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Ticket = reader["Ticket"].ToString(),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                });
            }
            return new PaginationHelper<Mission>(totalCount, request.PageSize, request.PageNumber, missions);
        }
    }

    public async Task<Mission> GetById(int id)
    {
        var command = CreateCommand("SELECT * FROM [Mission] WHERE Id=@id AND IsActive = 1");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Mission
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Descripton"].ToString(),
                    Status = reader["Status"].ToString(),
                    Priority = reader["Priority"].ToString(),
                    EstimatedEndDate = Convert.ToDateTime(reader["EstimatedEndDate"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Ticket = reader["Ticket"].ToString(),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                };
            }
            else
                return null;
        }
    }

    public async Task<Mission> GetByName(string name)
    {
        var command = CreateCommand("SELECT * FROM [Mission] WHERE Name = @name AND IsActive = 1");
        command.Parameters.AddWithValue("@name", name);

        using (var reader = command.ExecuteReader())
        {
            if (reader.HasRows && reader.Read())
            {
                return new Mission
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Descripton"].ToString(),
                    Status = reader["Status"].ToString(),
                    Priority = reader["Priority"].ToString(),
                    EstimatedEndDate = Convert.ToDateTime(reader["EstimatedEndDate"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Ticket = reader["Ticket"].ToString(),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                };
            }
            else
                return null;
        }
    }

    public PaginationHelper<Mission> GetByUserId(GetMissionModel request)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [Mission] WHERE UserId = @id AND IsActive = 1");
        command.Parameters.AddWithValue("@id", request.UserId);
        int totalCount = (int)command.ExecuteScalar();

        command.CommandText = $"SELECT * FROM [Mission] WHERE UserId = @id AND IsActive = 1 ORDER BY Id OFFSET {((request.PageNumber - 1) * request.PageSize)} ROWS FETCH NEXT {request.PageSize} ROWS ONLY";
        //command.Parameters.AddWithValue("@id", request.UserId);

        using (var reader = command.ExecuteReader())
        {
            List<Mission> missions = new List<Mission>();
            while (reader.Read())
            {
                missions.Add(new Mission
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Descripton"].ToString(),
                    Status = reader["Status"].ToString(),
                    Priority = reader["Priority"].ToString(),
                    EstimatedEndDate = Convert.ToDateTime(reader["EstimatedEndDate"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Ticket = reader["Ticket"].ToString(),
                    CreatorName = reader["CreatorName"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                });
            }
            return new PaginationHelper<Mission>(totalCount, request.PageSize, request.PageNumber, missions);
        }
    }

    public async Task<ResponseSalesDto> GetByUserIdForChart(int id)
    {
        var command = CreateCommand("SELECT * FROM [Mission] WHERE UserId = @id AND IsActive = 1");
        command.Parameters.AddWithValue("@id", id);

        using (var reader = command.ExecuteReader())
        {
            int[] doneCounts = new int[12];
            int[] notDoneCounts = new int[12];
            ResponseSalesDto dto = new ResponseSalesDto();

            while (reader.Read())
            {
                var mission = new Mission
                {
                    Status = reader["Status"].ToString(),
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                };


                if (mission.CreatedDate.HasValue)
                {
                    int month = mission.CreatedDate.Value.Month - 1; // Month is 1-based, array is 0-based

                    if (mission.Status == "Done")
                    {
                        doneCounts[month]++;
                    }
                    else
                    {
                        notDoneCounts[month]++;
                    }
                }
            }
                
            dto.Series = new List<SeriesDto>();
            dto.Series.Add(new SeriesDto { Name = "Tamamlanmayan Görevler", Data = notDoneCounts });
            dto.Series.Add(new SeriesDto { Name = "Tamamlanan Görevler", Data = doneCounts });
                
            return dto;
        }
    }
    #endregion
}
