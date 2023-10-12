using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Event_N52_HT1.Models
{
    public class AccountEventStore
    {
        public event Func<User, ValueTask>? OnUserCreated;

        public async ValueTask<User> CreateUserCreatedEventAsync(User user)
        {
            if (OnUserCreated != null)
                await OnUserCreated(user);

            return user;
        }
    }
}
