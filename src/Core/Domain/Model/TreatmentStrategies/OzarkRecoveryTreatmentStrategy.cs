using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.Core.Domain.Model.TreatmentStrategies
{
    public class OzarkRecoveryTreatmentStrategy : ITreatmentStrategy
    {
        public Treatment GenerateTreatment(Client client, Counselor counselor)
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
            var stepCount = 5;
            var steps = new List<Step>();
            steps.Add(new Step
            {
                Name = "Intake/Screening",
                Documents = new List<Document>
                {
                    new Document {Name = "Screening Form/Routing Sheet"},
                    new Document {Name = "SASSI III"},
                    new Document {Name = "Substance Abuse Assessment"},
                    new Document {Name = "Mental Health Screening"},
                    new Document {Name = "Handbook"}
                }
            });
            steps.Add(new Step
            {
                Name = "Admission/Orientation",
                Documents = new List<Document>
                {
                    new Document {Name = "Contact Information"},
                    new Document {Name = "Admission Documents (Consent/Confidentiality Forms)"},
                    new Document {Name = "Biophychosoical Assessment"},
                    new Document {Name = "Initial Treatment Plan"},
                    new Document {Name = "Admissions Report"}
                }
            });
            steps.Add(new Step { Name = "Treatment Planning" });
            steps.Add(new Step { Name = "Ongoing Progress Reporting" });
            steps.Add(new Step { Name = "Discharge/Followup" });
            return steps;
        }
    }
}
