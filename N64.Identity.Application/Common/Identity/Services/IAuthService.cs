using N64.Identity.Application.Common.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Application.Common.Identity.Services
{
    public interface IAuthService
    {
        ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);
        ValueTask<string> LoginAsync(LoginDetails loginDetails);
    }
}
