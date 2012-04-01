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
        public bool IsCompleted { get; set; }

        public Step CurrentStep
        {
            get
            {
                if (IsCompleted)
                {
                    return Step.Unassigned;
                }
                return Steps.Where(x => x.IsActive == true).FirstOrDefault();
            }
        }
    }
}