using System;
using System.Collections;
using System.Web.Mvc;
using NUnit.Framework;
using OzarkRecovery.Web.Controllers;

namespace OzarkRecovery.UnitTests
{
    public abstract class Behaves_like_CounselorController_spec : Specification
    {
        protected CounselorController _controller;

        protected override void Arrange()
        {
            _controller = new CounselorController();
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
        public void Should_return_a_list_of_counselors()
        {
            var vr = _result as ViewResult;
            Assert.That((vr.Model as IList).Count, Is.GreaterThan(0));
        }
    }
}