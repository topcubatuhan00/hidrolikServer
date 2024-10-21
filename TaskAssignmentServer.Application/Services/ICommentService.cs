using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.CommentModels;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Application.Services;

public interface ICommentService
{
    Task<ResponseDto<Comment>> GetById(int id);
    Task<List<Comment>> GetComments(GetCommentModel model);
    Task<List<Comment>> GetCommentsByUserId(int userId);
    Task<ResponseDto<PaginationHelper<Comment>>> GetAll(PaginationRequest request);
    Task Create(CreateCommentModel model);
    Task Update(UpdateCommentModel model);
    Task Remove(int id);
}
