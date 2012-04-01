using System;
using System.Collections.Generic;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Client : Entity
    {
        public Client()
        {
            Treatments = new List<Treatment>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IList<Treatment> Treatments { get; set; }

        public string FullName
        {
            get { return (FirstName + " " + LastName).Trim(); }
        }
    }
}