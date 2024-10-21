using Hidrolik.Domain.Core;

namespace Hidrolik.Domain.Entities;

public class AutoReminder : EntityBase
{
    public DateTime CycleTime { get; set; }
    public int MissionId { get; set; }
}
