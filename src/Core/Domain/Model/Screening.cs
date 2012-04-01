using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Screening: Entity
    {
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
