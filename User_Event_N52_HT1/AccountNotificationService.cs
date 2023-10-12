using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Event_N52_HT1.Models;

namespace User_Event_N52_HT1
{
    public class AccountNotificationService
    {
        private readonly AccountEventStore _accountEventStore;

        public AccountNotificationService(AccountEventStore accountEventStore)
        {
            _accountEventStore = accountEventStore;
        }

        public async ValueTask<User> Create(User user)
        {
            await _accountEventStore.CreateUserCreatedEventAsync(user);
            
            return user;
        }
    }
}
