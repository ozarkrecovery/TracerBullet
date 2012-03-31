using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Step
    {
        public string Name { get; set; }
        public IList<Document> Documents { get; set; }
    }
}
