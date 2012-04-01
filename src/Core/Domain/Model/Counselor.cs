using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Counselor : Entity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public IList<Treatment> Treatments { get; set; }
        public bool IsSupervisor { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }
}
