using Hidrolik.Domain.Core;

namespace Hidrolik.Domain.Entities;

public class Mission : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime EstimatedEndDate { get; set; }
    public int UserId { get; set; }
    public string Ticket { get; set; }
}
