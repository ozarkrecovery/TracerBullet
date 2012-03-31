using System;
using NUnit.Framework;

namespace OzarkRecovery.UnitTests
{
    public abstract class Specification
    {
        [SetUp]
        public void Setup()
        {
            Arrange();
            Act();
        }

        protected abstract void Arrange();
        protected abstract void Act();
        //protected abstract T Mock<T>() where T : class;

        [TearDown]
        public virtual void TearDown()
        {
        }
    }
}