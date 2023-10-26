using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Infrastructure.Common.Identity.Services
{
    public class AuthService : IAuthService
    {
        
        private readonly TokenGeneratorService _tokenGeneratorService;

        public AuthService(TokenGeneratorService tokenGeneratorService)
        {
            _tokenGeneratorService = tokenGeneratorService;
        }

        private static readonly List<User> _users = new();

        public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = registrationDetails.FirstName,
                LastName = registrationDetails.LastName,
                Age = registrationDetails.Age,
                EmailAddress = registrationDetails.EmailAddress,
                Password = registrationDetails.Password
            };

            _users.Add(user);
            return new(true);
        }

        public ValueTask<string> LoginAsync(LoginDetails loginDetails)
        {
            var foundUser = _users.FirstOrDefault(x => x.EmailAddress == loginDetails.EmailAddress && x.Password == loginDetails.Password);

            if (foundUser is null)
                throw new AuthenticationException("Login details are invalid, contact support.");

            var accessToken = _tokenGeneratorService.GetToken(foundUser);
            return new(accessToken);
        }
    }
}
