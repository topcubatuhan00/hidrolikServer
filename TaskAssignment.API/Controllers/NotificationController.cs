using Microsoft.AspNetCore.Mvc;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Models.NotificationModels;

namespace Hidrolik.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateNotificationModel model)
    {
        await _notificationService.Create(model);
        return Ok("Bildirim Eklendi.");
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var result = await _notificationService.GetByUserId(userId);
        return Ok(result);
    }
}
