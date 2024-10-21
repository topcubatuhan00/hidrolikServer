namespace Hidrolik.Domain.Models.AutoReminder;

public class CreateReminderModel
{
    public DateTime CycleTime { get; set; }
    public int MissionId { get; set; }
    public string CreatorName { get; set; }
}
