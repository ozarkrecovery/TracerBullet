using System;
using System.Collections.Generic;
using System.Linq;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Treatment : Entity
    {
        public Client Client { get; set; }
        public Counselor Counselor { get; set; }
        public IList<Step> Steps { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string CurrentStep
        {
            get { return Steps.Last().Name; }
        }
    }
}