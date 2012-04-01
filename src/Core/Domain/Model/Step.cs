using System;
using System.Collections.Generic;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Step : Entity
    {
        public static Step Unassigned = new Step {Name = "Unassigned"};

        public Step()
        {
            Documents = new List<Document>();
            Phases = new List<Phase>();
            Surveys = new List<Survey>();
        }

        public short Sequence { get; set; }
        public string Name { get; set; }
        public virtual IList<Document> Documents { get; set; }
        public virtual IList<Phase> Phases { get; set; }
        public virtual IList<Survey> Surveys { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public void Begin()
        {
            StartDate = DateTime.Now;
            IsActive = true;
        }

        public void End()
        {
            EndDate = DateTime.Now;
            IsActive = false;
        }
    }
}