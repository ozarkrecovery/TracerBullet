using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Core.Domain.Model.TreatmentStrategies;
using NUnit.Framework;

namespace OzarkRecovery.UnitTests
{
    public class When_creating_a_Treatment : Specification
    {
        private ITreatmentStrategy _strategy;
        private Treatment _treatment;
        private Client _client;
        private Counselor _counselor;
        
        protected override void Arrange()
        {
            _strategy = new OzarkRecoveryTreatmentStrategy();
            _client = new Client{ Id=1234, FirstName="John", LastName="Doe"};
            _counselor = new Counselor {Id = 5678, FirstName = "Jane", LastName = "Doe"};
        }

        protected override void Act()
        {
            _treatment = _strategy.GenerateTreatment(_client, _counselor);
        }

        [Test]
        public void It_should_return_a_Treatment()
        {
            Assert.That(_treatment, Is.Not.Null);
            Assert.That(_treatment, Is.InstanceOf<Treatment>());
        }

        [Test]
        public void It_should_return_a_Treatment_with_5_steps()
        {
            Assert.That(_treatment.Steps.Count, Is.EqualTo(5));
        }

        [Test]
        public void It_should_return_a_first_step_with_5_documents()
        {
            Assert.That(_treatment.Steps.First().Documents.Count, Is.EqualTo(5));
        }

        [Test]
        public void It_should_return_a_first_step_with_0_phases()
        {
            Assert.That(_treatment.Steps.First().Phases.Count, Is.EqualTo(6));
        }

        [Test]
        public void It_should_return_a_first_step_with_0_surveys()
        {
            Assert.That(_treatment.Steps.First().Surveys.Count, Is.EqualTo(6));
        }
        [Test]
        public void It_should_return_a_second_step_with_5_documents()
        {
            Assert.That(_treatment.Steps[1].Documents.Count, Is.EqualTo(5));
        }

        [Test]
        public void It_should_return_a_second_step_with_0_phases()
        {
            Assert.That(_treatment.Steps[1].Phases.Count, Is.EqualTo(6));
        }

        [Test]
        public void It_should_return_a_second_step_with_0_surveys()
        {
            Assert.That(_treatment.Steps[1].Surveys.Count, Is.EqualTo(6));
        }

    }
}
