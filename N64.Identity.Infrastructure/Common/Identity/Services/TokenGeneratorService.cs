using N64.Identity.Application.Common.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Infrastructure.Common.Identity.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string SecretKey = "9CAF9173-6E18-4C45-9D17-B0698D91D553";

        public string GetToken(User user)
        {
            var jwtToken = GetJwtToken(user);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        public JwtSecurityToken GetJwtToken(User user)
        {
            var claims = GetClaims(user);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(issuer: "Todo.ServerApp",
                audience: "Todo.ClientApp",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
        }

        private List<Claim> GetClaims(User user)
        {
            return new List<Claim>
            {
                new (ClaimTypes.Email, user.EmailAddress),
                new (ClaimConstants.UserId, user.Id.ToString())
            };
        }
    }
}
