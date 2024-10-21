using Microsoft.AspNetCore.Mvc;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Models.HelperModels;
using Hidrolik.Domain.Models.UserModels;

namespace Hidrolik.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    #region Fields
    private readonly IUserService _userService;
    #endregion

    #region Ctor
    public UserController
    (
        IUserService userService
    )
    {
        _userService = userService;
    }
    #endregion

    #region Methods
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserModel model)
    {
        await _userService.Create(model);
        return Ok("Kullanıcı Başarıyla Oluşturuldu");
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateUserModel model)
    {
        await _userService.Update(model);
        return Ok("Kullanıcı Başarıyla Güncellendi");
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateRole(UpdateUserRoleModel model)
    {
        await _userService.UpdateRole(model);
        return Ok("Kullanıcı Rolü Başarıyla Güncellendi");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _userService.Remove(id);
        return Ok("Kullanıcı Başarıyla Kaldırıldı");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var result = await _userService.GetAll(request);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _userService.GetById(id);

        return Ok(result);
    }
    #endregion
}
