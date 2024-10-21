namespace Hidrolik.Domain.Models.MissionModels;

public class UpdateMissionModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime EstimatedEndDate { get; set; }
    public int UserId { get; set; }
    public string Ticket { get; set; }
    public string UpdaterName { get; set; }
    public bool IsActive { get; set; }
}
