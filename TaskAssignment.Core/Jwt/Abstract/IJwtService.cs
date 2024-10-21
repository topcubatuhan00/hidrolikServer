using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Core.Jwt.Abstract;

public partial interface IJwtService
{
    TokenResponseModel CreateToken(User user);
}
