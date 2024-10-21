using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.CommentModels;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Domain.Repositories.CommentRepositories;

public interface ICommentQueryRepository
{
    PaginationHelper<Comment> GetAll(PaginationRequest request);
    Task<Comment> GetById(int id);
    Task<List<Comment>> GetByIdUserId(int id);
    Task<List<Comment>> GetComments(GetCommentModel model);
}
