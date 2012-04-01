using System;
using System.Collections.Generic;

namespace OzarkRecovery.Web.Models
{
    public class CounselorShowModel
    {
        public bool CanAddTreatment { get; set; }
        public string CounselorName { get; set; }
        public IEnumerable<ClientModel> AssignedClients { get; set; }

        public class ClientModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int TreatmentNumber { get; set; }
            public string CurrentStep { get; set; }
        }
    }
}