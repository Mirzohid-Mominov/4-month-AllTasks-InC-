using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Event_N52_HT1.Models;

namespace User_Event_N52_HT1
{
    public class EmailSenderService
    {
        public void SendEmailAsync(User user)
        {
            Console.WriteLine($"Welcome {user.EmailAddress}");
        }
    }
}
