using Microsoft.AspNetCore.Mvc;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Models.AutoReminder;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutoReminderController : ControllerBase
{
    #region Fields
    private readonly IAutoReminderService _autoReminderService;
    #endregion

    #region Ctor
    public AutoReminderController
    (
        IAutoReminderService autoReminderService
    )
    {
        _autoReminderService = autoReminderService;
    }
    #endregion


    #region Methods
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateReminderModel model)
    {
        await _autoReminderService.Create(model);
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateReminderModel model)
    {
        await _autoReminderService.Update(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _autoReminderService.Remove(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var reminders = await _autoReminderService.GetAll(request);

        return Ok(reminders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _autoReminderService.GetById(id);

        return Ok(category);
    }
    #endregion


}
