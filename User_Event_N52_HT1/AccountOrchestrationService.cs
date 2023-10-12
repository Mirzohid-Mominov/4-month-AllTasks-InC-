using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Event_N52_HT1.Models;

namespace User_Event_N52_HT1
{
    public class AccountOrchestrationService
    {
        private readonly AccountEventStore _accountEventStore;

        public AccountOrchestrationService(AccountEventStore accountEventStore)
        {
            _accountEventStore = accountEventStore;
            _accountEventStore.OnUserCreated += HandleUserCreatedEventAsync;
        }

        public ValueTask HandleUserCreatedEventAsync(User user)
        {
            var email = new EmailSenderService();
            email.SendEmailAsync(user);

            return new ValueTask();
        }
    }
}
