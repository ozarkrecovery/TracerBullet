using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
	public class Program : Entity
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IList<Phase> Phases { get; set; }
		public Treatment Treatment { get; set; }
	}
}
