namespace Hidrolik.Domain.Models.MissionModels;

public class CreateMissionModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime EstimatedEndDate { get; set; }
    public int UserId { get; set; }
    public string Ticket { get; set; }
    public string CreatorName { get; set; }
}
