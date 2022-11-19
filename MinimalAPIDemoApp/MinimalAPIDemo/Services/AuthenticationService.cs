using DataAccess.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinimalAPIDemo.Config;
using MinimalAPIDemo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalAPIDemo.Services
{
    public class AuthenticationService
    {
        
        public string GetToken(UserModel loggedUser, ModelUserLogin userlogin, IOptions<JwtConfig> options)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loggedUser.UserName),
                new Claim(ClaimTypes.Email, loggedUser.EmailAddress),
                new Claim(ClaimTypes.GivenName, loggedUser.FirstName),
                new Claim(ClaimTypes.Surname, loggedUser.LastName),
                new Claim(ClaimTypes.Role, loggedUser.Role)
            };

            var token = new JwtSecurityToken
                (
                    issuer: options.Value.Issuer,
                    audience: options.Value.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Key)),
                        SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }
    }
}
