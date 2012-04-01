using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Web.Models
{
    public class CounselorIndexModel
    {
        public Counselor User { get; private set; }
        public IList<Counselor> Counselors { get; private set; }

        public CounselorIndexModel(Counselor user, IList<Counselor> counselors)
        {
            User = user;
            Counselors = counselors;
        }
    }
}