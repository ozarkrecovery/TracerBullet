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
            get { return IsCompleted ? Step.Unassigned : Steps.Where(x => x.IsActive).FirstOrDefault(); }
        }

        public void Advance()
        {
            if (CurrentStep == Step.Unassigned) return;

            var nextStep = Steps.SingleOrDefault(x => x.Sequence == CurrentStep.Sequence + 1);

            CurrentStep.End();

            if (nextStep != null)
                nextStep.Begin();
        }
    }
}