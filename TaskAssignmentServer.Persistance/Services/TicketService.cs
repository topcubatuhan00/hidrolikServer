using AutoMapper;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Dtos;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Helpers;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.TicketModels;
using Hidrolik.Domain.UnitOfWork;

namespace Hidrolik.Persistance.Services;

public class TicketService : ITicketService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public TicketService
    (
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    #endregion

    public async Task Create(CreateTicketModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<Ticket>(model);
            await context.Repositories.ticketCommandRepository.AddAsync(entity);
            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<Ticket>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.ticketQueryRepository.GetAll(request);
            var paginationHelper = new PaginationHelper<Ticket>(result.TotalCount, request.PageSize, request.PageNumber, null);
            var items = result.Items.Select(item => _mapper.Map<Ticket>(item)).ToList();
            paginationHelper.Items = items;
            return ResponseDto<PaginationHelper<Ticket>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Ticket>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.ticketQueryRepository.GetById(id);
            return ResponseDto<Ticket>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.ticketQueryRepository.GetById(id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.ticketCommandRepository.RemoveById(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateTicketModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.ticketQueryRepository.GetById(model.Id);
            if (check == null) throw new Exception("Not Found");

            var entity = _mapper.Map<Ticket>(model);
            await context.Repositories.ticketCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
}
