using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Core.Domain.Interfaces
{
    public interface ITreatmentStrategy
    {
        Treatment CreateTreatment(Client client, Counselor counselor);
    }
}
