using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
	public class Phase : Entity
	{
		public string Name { get; set; }
        public IList<Meeting> Meetings { get; set; }
        public IList<Srceening> Screenings { get; set; }
        public IList<Assignment> Assignments { get; set; }

	}
}
