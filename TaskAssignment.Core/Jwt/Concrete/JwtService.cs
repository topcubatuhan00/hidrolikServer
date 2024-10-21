using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hidrolik.Core.Jwt.Abstract;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.Core.Jwt.Concrete;

public class JwtService : IJwtService
{
    #region Fields
    private readonly IConfiguration _configuration;
    #endregion

    #region Ctor
    public JwtService
    (
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }
    #endregion

    #region Methods
    public TokenResponseModel CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("Role", user.Role),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return new TokenResponseModel { Token = jwt, ExpirationDate = token.ValidTo };
    }
    #endregion
}
