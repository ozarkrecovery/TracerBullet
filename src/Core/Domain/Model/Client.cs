using System.Collections.Generic;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Program> Program { get; set; }
    }
}