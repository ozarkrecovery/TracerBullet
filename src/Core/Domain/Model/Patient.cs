using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
   public class Patient : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Program> Program { get; set; }
    }
}
