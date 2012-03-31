using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class User : Entity
    {
        public User()
        {
        }

        public string Username { get; set; }
        public string Password { get; set; }

    }
}
