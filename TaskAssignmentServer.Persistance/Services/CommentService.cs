using AutoMapper;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.CommentModels;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.UnitOfWork;

namespace Hidrolik.Persistance.Services;

public class CommentService : ICommentService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public CommentService
    (
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    #endregion

    public async Task Create(CreateCommentModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<Comment>(model);
            await context.Repositories.commentCommandRepository.AddAsync(entity);
            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<Comment>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.commentQueryRepository.GetAll(request);
            var paginationHelper = new PaginationHelper<Comment>(result.TotalCount, request.PageSize, request.PageNumber, null);
            var items = result.Items.Select(item => _mapper.Map<Comment>(item)).ToList();
            paginationHelper.Items = items;
            return ResponseDto<PaginationHelper<Comment>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Comment>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.commentQueryRepository.GetById(id);
            return ResponseDto<Comment>.Success(result, 200);
        }
    }

    public async Task<List<Comment>> GetComments(GetCommentModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.commentQueryRepository.GetComments(model);
            return result;
        }
    }

    public async Task<List<Comment>> GetCommentsByUserId(int userId)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.commentQueryRepository.GetByIdUserId(userId);
            return result;
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.commentQueryRepository.GetById(id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.commentCommandRepository.RemoveById(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateCommentModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.commentQueryRepository.GetById(model.Id);
            if (check == null) throw new Exception("Not Found");

            var entity = _mapper.Map<Comment>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = model.UpdaterName;
            await context.Repositories.commentCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
}
