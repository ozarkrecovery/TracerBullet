using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OzarkRecovery.Infrastructure.DependencyResolution;
using OzarkRecovery.Core.Domain.Interfaces;
using StructureMap;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.UnitTests
{
    [TestFixture]
    public class RepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            BootStrapper.RegisterIoC();
            //Arrange();
            //Act();
        }

        //protected abstract void Arrange();
        //protected abstract void Act();
        //protected T Mock<T>() where T : class
        //{
        //    return MockRepository.GenerateMock<T>();
        //}

        [TearDown]
        public virtual void TearDown()
        {
        }

        [Test]
        public void TestRepository()
        {
            var repo = ObjectFactory.GetInstance<IRepository>();
            var client = repo.Find<Client>(c => c.Id == 1);
            Assert.AreEqual(client.Count(), 1);
        }
    }
}
