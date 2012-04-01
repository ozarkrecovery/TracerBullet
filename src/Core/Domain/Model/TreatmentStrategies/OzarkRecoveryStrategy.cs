using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Core.Domain.Model.TreatmentStrategies
{
    public class OzarkRecoveryStrategy : ITreatmentStrategy
    {
        public Treatment CreateTreatment(Client client, Counselor counselor)
        {
            var treatment = new Treatment();
            treatment.StartDate = DateTime.Now;
            treatment.Client = client;
            treatment.Counselor = counselor;
            treatment.Steps = GenerateSteps();
            return treatment;
        }

        private IList<Step> GenerateSteps()
        {
            var steps = new List<Step>();
            steps.Add(new Step {Name = "Intake/Screening" });
            steps.Add(new Step {Name = "Admission/Orientation" });
            steps.Add(new Step {Name = "Treatment Planning" });
            steps.Add(new Step {Name = "Ongoing Progress Reporting" });
            steps.Add(new Step {Name = "Discharge/Followup" });
            return steps;
        }
    }
}
