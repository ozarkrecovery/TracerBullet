using System;
using Rhino.Mocks;
using NUnit.Framework;

namespace OzarkRecovery.UnitTests
{
    [TestFixture]
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
        protected T Mock<T>() where T : class
        {
        	return MockRepository.GenerateMock<T>();
        }

    	[TearDown]
        public virtual void TearDown()
        {
        }
    }
}