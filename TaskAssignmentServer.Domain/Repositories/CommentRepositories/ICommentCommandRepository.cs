using Hidrolik.Domain.Entities;

namespace Hidrolik.Domain.Repositories.CommentRepositories;

public interface ICommentCommandRepository
{
    Task AddAsync(Comment entity);
    Task UpdateAsync(Comment entity);
    Task RemoveById(int id);
}
