using System;
using System.Collections.Generic;
using System.Linq;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Treatment> Treatments { get; set; }

        public string FullName
        {
            get { return (FirstName + " " + LastName).Trim(); }
        }

        public Step CurrentStep
        {
            get
            {
                return null;
            }

        }
    }
}