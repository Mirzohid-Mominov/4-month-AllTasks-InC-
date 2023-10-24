using DemoWebUser.Models;
using Mapster;

namespace DemoWebUser.Services
{
    public class UserService
    {
        public List<User> _users = new List<User>();

        public User Create (UserForCreation userForCreation)
        {
            var foundUser = _users.FirstOrDefault(x => x.Email == userForCreation.Email);
            if (foundUser != null)
            {
                Console.WriteLine("This user ix already existed");
                return foundUser;
            }

            var newUser = userForCreation.Adapt<User>();

            newUser.DateOfBearth = DateTime.UtcNow;
            newUser.Id = Guid.NewGuid();

            _users.Add(newUser);

            return newUser;
        }

        public UserVievModel Get(Guid id)
        {
            var user = _users.FirstOrDefault(x => x.Id  == id);

            var userVievModel = user.Adapt<UserVievModel>();
            return userVievModel;
        }
    }
}
