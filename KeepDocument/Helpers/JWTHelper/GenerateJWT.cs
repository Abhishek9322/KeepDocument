using KeepDocument.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KeepDocument.Helpers.JWTHelper
{
    public class GenerateJWT
    {
        private readonly JWTOption _jwtOption;
        public GenerateJWT(IOptions<JWTOption> jwtOption)
        {
            _jwtOption = jwtOption.Value;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email)
            };

            var token = new JwtSecurityToken(
                 issuer: _jwtOption.Issuer,
                 audience: _jwtOption.Audience,
                 claims: claims,
                 expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
