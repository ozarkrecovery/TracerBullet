using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Treatment : Entity
    {
        public Client Client { get; set; }
        public Counselor Counselor { get; set; }
        public IList<Step> Steps { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
