using System.Collections.Generic;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public List<Program> Program { get; set; }

        public string FullName
        {
            get { return (FirstName + " " + LastName).Trim(); }
        }
        public string CurrentPhase
        {
            get { return "Not sure yet"; }
        }
    }
}
