using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Web.Controllers;
using OzarkRecovery.Core.Domain.Interfaces;

namespace OzarkRecovery.UnitTests
{
    public abstract class Behaves_like_CounselorController_spec : Specification
    {
        protected CounselorController _controller;

        protected override void Arrange()
        {
            _controller = new CounselorController(Mock<IRepository>());
        }
    }

    public class When_hitting_the_index_action : Behaves_like_CounselorController_spec
    {
        private ActionResult _result;

        protected override void Act()
        {
            _result = _controller.Index();
        }

        [Test]
        public void Should_return_a_list_of_patients()
        {
            var vr = _result as ViewResult;
            var model = vr.Model as IList<Client>;
            Assert.That(model.Count, Is.GreaterThan(0));
        }
    }
}