using Hidrolik.Domain.Core;

namespace Hidrolik.Domain.Entities;

public class Comment : EntityBase
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public int MissionId { get; set; }
    public string FilePathName { get; set; }
}
