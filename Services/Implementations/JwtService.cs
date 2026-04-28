using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Sem2FirstProject.Services.Implementations
{
    public class JwtService
    {
        public async Task<string> GenerateToken()
        {
            var secretKey = "MySecretKey";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenObj =  new JwtSecurityToken(
                issuer: "MyCompany",
                audience: "React",
                claims: [],
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(5)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenObj);

            return token;
        }
    }
}
