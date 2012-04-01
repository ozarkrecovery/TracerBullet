using System;
using System.Collections.Generic;

namespace OzarkRecovery.Web.Models
{
    public class CounselorIndexModel
    {
        public bool IsAdmin { get; set; }
        public IEnumerable<CounselorModel> Counselors { get; set; }

        public class CounselorModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ActiveClients { get; set; }
        }
    }
}