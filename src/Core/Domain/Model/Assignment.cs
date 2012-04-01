using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Assignment : Entity
    {
        public string Name { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
