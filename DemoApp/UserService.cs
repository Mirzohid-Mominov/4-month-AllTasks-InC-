using DemoApp.Dtos;
using DemoApp.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp;

public class UserService
{
    private List<User> _users = new List<User>();
    public User Create(UserForCreation user)
    {
        var foundUser = _users.FirstOrDefault(x => x.Email.Equals(user.Email));

        if (foundUser != null)
        {
            Console.WriteLine("This user already existed");
            return foundUser;
        }

        var newUser = user.Adapt<User>();

        newUser.CreatedAt = DateTime.UtcNow;
        newUser.UpdatedAt = DateTime.UtcNow;
        newUser.Id = Guid.NewGuid();

        _users.Add(newUser);

        return newUser;
    }

    public List<UserVievModel> GetUsers()
    {
        return _users.Adapt<List<UserVievModel>>();
    }
}
