using System;
using System.Collections.Generic;
using System.Linq;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Treatment : Entity
    {
        public virtual Client Client { get; set; }
        public virtual Counselor Counselor { get; set; }
        public virtual IList<Step> Steps { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string CurrentStep
        {
            get
            {
                var step = Steps.OrderBy(x => x.Id).Where(x => x.StartDate != null && x.EndDate == null).FirstOrDefault();
                return step != null ? step.Name : "None";
            }
        }
    }
}