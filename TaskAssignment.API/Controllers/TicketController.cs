using Microsoft.AspNetCore.Mvc;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.TicketModels;

namespace Hidrolik.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
	#region Fields
	private readonly ITicketService _ticketService;
    #endregion

    #region Ctor
    public TicketController
    (
        ITicketService ticketService
    )
    {
        _ticketService = ticketService;
    }
    #endregion

    #region Methods
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateTicketModel model)
    {
        await _ticketService.Create(model);
        return Ok("Etiket Başarıyla Eklendi");
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateTicketModel model)
    {
        await _ticketService.Update(model);
        return Ok("Etiket Başarıyla Güncellendi");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _ticketService.Remove(id);
        return Ok("Etiket Başarıyla Kaldırıldı");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var result = await _ticketService.GetAll(request);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _ticketService.GetById(id);

        return Ok(result);
    }
    #endregion

}
