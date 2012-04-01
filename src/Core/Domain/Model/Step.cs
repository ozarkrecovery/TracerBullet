using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Step : Entity
    {
        public static Step Unassigned = new Step { Name = "Unassigned" };

        public short Sequence { get; set; }
        public string Name { get; set; }
        public IList<Document> Documents { get; set; }
        public IList<Phase> Phases { get; set; }
        public IList<Survey> Surveys { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Step()
        {
            Documents = new List<Document>();
            Phases = new List<Phase>();
            Surveys = new List<Survey>();
        }
    }
}
