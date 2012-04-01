using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Core.Domain.Model
{
    public class Meeting : Entity
    {
        public MeetingType Type { get; set; }
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
    }
}
