using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OzarkRecovery.Infrastructure.DependencyResolution;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Core.Domain.Model;
using StructureMap;
using System.Data.Entity;
using System.Data;
using OzarkRecovery.Infrastructure.DataAccess;



namespace IntergationTestMS
{
    [TestClass]
    public class repoTest
    {
        [TestInitialize]
        public void TestSetup()
        {
            BootStrapper.RegisterIoC();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //Database.SetInitializer<ORContext>(new DropCreateDatabaseAlways<ORContext>());
            IRepository repo = ObjectFactory.GetInstance<IRepository>();
            Client newClient = new Client();
            newClient.FirstName = "John";
            newClient.LastName = "Smith";
            repo.Add<Client>(newClient);

            newClient = new Client();
            newClient.FirstName = "Jane";
            newClient.LastName = "Doe";
            repo.Add<Client>(newClient);

            repo.Commit();
            var client = repo.Find<Client>(c => c.Id == 1);
            Assert.AreEqual(client.Count(), 1); 
        }
    }
}
