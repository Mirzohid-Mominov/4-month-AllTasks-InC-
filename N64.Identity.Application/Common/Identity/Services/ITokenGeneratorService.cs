using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Application.Common.Identity.Services
{
    public interface ITokenGeneratorService
    {
        string GetToken(user user)
        JwtSecurityToken GetJwtToken(User user);
        List<Claim> GetClaims(User user);
    }
}
