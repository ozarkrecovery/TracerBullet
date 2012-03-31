using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Counselor : Entity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}
