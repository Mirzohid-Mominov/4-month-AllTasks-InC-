using IEntity_TokenGenerator.Models.Dtos;
using IEntity_TokenGenerator.Models.Entities;
using System.Security.Authentication;

namespace IEntity_TokenGenerator.Services
{
    public class AuthService
    {
        private readonly TokenGeneratorService _tokenGeneratorService;

        public AuthService(TokenGeneratorService tokenGeneratorService)
        {
            _tokenGeneratorService = tokenGeneratorService;
        }

        private static readonly List<User> _users = new ();

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
            return new (accessToken);
        }
    }
}
