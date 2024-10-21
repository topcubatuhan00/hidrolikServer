namespace Hidrolik.Domain.Models.AutoReminder;

public class UpdateReminderModel
{
    public int Id { get; set; }
    public DateTime CycleTime { get; set; }
    public int MissionId { get; set; }
    public string UpdaterName { get; set; }
    public bool IsActive { get; set; }
}
