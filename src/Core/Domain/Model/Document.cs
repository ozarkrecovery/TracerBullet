using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Document
    public class Document: Entity
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }

    }
}
