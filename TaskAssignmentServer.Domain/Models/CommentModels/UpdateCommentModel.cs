namespace Hidrolik.Domain.Models.CommentModels;

public class UpdateCommentModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public int MissionId { get; set; }
    public string FilePathName { get; set; }
    public string UpdaterName { get; set; }
}
