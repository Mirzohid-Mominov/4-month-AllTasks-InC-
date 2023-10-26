using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.Identity.Application.Common.Settings
{
    public class JwtSettings
    {
        public bool ValidateIsUser { get; set; }
        public string ValidIsUser { get; set; }
        public string ValidateAudience { get; set; }
        public string ValidAudience { get; set; }
        public bool ValidateLifeTime { get; set; }
        public bool ExpirationTimeInMinutes { get; set; }
        public bool ValidateIsUserSigningKey { get; set; }
        public string SecretKey { get; set;}
    }
}
