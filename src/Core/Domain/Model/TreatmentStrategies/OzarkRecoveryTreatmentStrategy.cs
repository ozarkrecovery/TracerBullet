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
            var steps = new List<Step>();
            steps.Add(new Step
            {
                Sequence = 1,
                Name = "Intake/Screening",
                StartDate = DateTime.Now,
                IsActive = true,
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
                Sequence = 2,
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
            steps.Add(new Step
            {
                Sequence = 3,
                Name = "Treatment Planning",
                Documents = new List<Document>
                {
                    new Document {Name = "Treatment Checklist"},
                    new Document {Name = "Master Treatment Plan"},
                    new Document {Name = "SNAPP Note"},
                    new Document {Name = "ASI"},
                    new Document {Name = "Doctor Letters"}
                }
            });
            steps.Add(new Step
            {
                Sequence = 4,
                Name = "Ongoing Progress Reporting",
                Documents = new List<Document>
                {
                    new Document {Name = "Progress/Communication Notes"},
                    new Document {Name = "Group Notes"},
                    new Document {Name = "Court Report"}
                },
                Phases = new List<Phase>
                {
                    GeneratePhase("Phase I"),
                    GeneratePhase("Phase II"),
                    GeneratePhase("Phase III"),
                    GeneratePhase("Phase IV")
                }
            });
            steps.Add(new Step
            {
                Sequence = 5,
                Name = "Discharge/Followup",
                Documents = new List<Document>
                {
                    new Document {Name = "Progress/Communication Notes"},
                    new Document {Name = "Group Notes"},
                    new Document {Name = "Court Report"}
                },
                Surveys = new List<Survey>
                {
                    new Survey{ Name="30 Day Followup"},                
                    new Survey{ Name="6 Month Followup"},
                    new Survey{ Name="12 Month Followup"}
                }
            });
            return steps;
        }

        private Phase GeneratePhase(string name)
        {
            return new Phase
            {
                Name = name,
                Meetings = new List<Meeting>(),
                Screenings = new List<Screening>(),
                Assignments = new List<Assignment>()
            };
        }
    }
}
