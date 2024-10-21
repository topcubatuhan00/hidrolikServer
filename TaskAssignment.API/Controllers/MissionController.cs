using Microsoft.AspNetCore.Mvc;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.MissionModels;

namespace Hidrolik.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MissionController : ControllerBase
{
    #region Fields
    private readonly IMissionService _missionService;
    #endregion

    #region Ctor
    public MissionController
    (
        IMissionService missionService
    )
    {
        _missionService = missionService;
    }
    #endregion

    #region Methods
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMissionModel model)
    {
        await _missionService.Create(model);
        return Ok("Görev Başarıyla Kayıt Edildi");
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateMissionModel model)
    {
        await _missionService.Update(model);
        return Ok("Görev Başarıyla Güncellendi");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _missionService.Remove(id);
        return Ok("Görev Başarıyla Kaldırıldı");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var result = await _missionService.GetAll(request);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _missionService.GetById(id);

        return Ok(result);
    }

    [HttpGet("User")]
    public async Task<IActionResult> GetByUserId([FromQuery] GetMissionModel request)
    {
        var result = await _missionService.GetByUserId(request);

        return Ok(result);
    }

    [HttpGet("UserChart/{chartUserId}")]
    public async Task<IActionResult> GetByUserIdForChart(int chartUserId)
    {
        var result = await _missionService.GetByUserIdForChart(chartUserId);

        return Ok(result);
    }

    [HttpGet("User2/{name}")]
    public async Task<IActionResult> GetByUserId(string name)
    {
        var result = await _missionService.GetByName(name);

        return Ok(result);
    }
    #endregion
}
