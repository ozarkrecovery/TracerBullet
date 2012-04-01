using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Core.Domain.Model.TreatmentStrategies
{
    public class OzarkRecoveryStrategy : ITreatmentStrategy
    {
        public Treatment CreateTreatment()
        {
            var treatment = new Treatment();
            return treatment;
        }
    }
}
