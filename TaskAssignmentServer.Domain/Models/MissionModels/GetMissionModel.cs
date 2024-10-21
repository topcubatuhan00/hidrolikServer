namespace Hidrolik.Domain.Models.MissionModels;

public class GetMissionModel
{
    public int UserId { get; set; }
    public virtual int PageNumber { get; set; }
    public virtual int PageSize { get; set; }
}
