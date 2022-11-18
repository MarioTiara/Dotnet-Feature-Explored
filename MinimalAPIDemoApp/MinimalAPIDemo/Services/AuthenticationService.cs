using DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using MinimalAPIDemo.Configuration;
using MinimalAPIDemo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalAPIDemo.Services
{
    public class AuthenticationService
    {
        private readonly JwtConfig _jwtConfig;
        public AuthenticationService(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public string GetToken(UserModel loggedUser, ModelUserLogin userlogin)
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
                    issuer: _jwtConfig.Issuer,
                    audience: _jwtConfig.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key)),
                        SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }
    }
}
