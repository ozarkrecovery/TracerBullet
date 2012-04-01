using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

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

        public Step CurrentStep
        {
            get
            {
                return null;
            }

        }
    }
}