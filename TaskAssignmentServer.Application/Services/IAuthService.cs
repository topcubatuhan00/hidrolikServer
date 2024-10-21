using Hidrolik.Domain.Models.Auth;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Application.Services;

public interface IAuthService
{
    Task<TokenResponseModel> Login(AuthLoginModel model);
    Task Register(AuthRegisterModel user);
}
