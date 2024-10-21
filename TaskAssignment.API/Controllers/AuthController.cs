using Microsoft.AspNetCore.Mvc;
using Hidrolik.API.CustomControllerBase;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Models.Auth;

namespace TasHidrolikkAssignment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    #region Fields
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;
    #endregion

    #region Ctor
    public AuthController
    (
        IConfiguration configuration,
        IAuthService authService
    )
    {
        _configuration = configuration;
        _authService = authService;
    }
    #endregion

    #region Methods

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(AuthLoginModel model)
    {
        var token = await _authService.Login(model);
        return Ok(token);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(AuthRegisterModel user)
    {
        await _authService.Register(user);
        return Ok();
    }
    #endregion
}
