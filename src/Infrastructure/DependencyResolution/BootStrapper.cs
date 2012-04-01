using System;
using StructureMap;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Infrastructure.DataAccess.Impl;
using System.Data.Entity;
using OzarkRecovery.Infrastructure.DataAccess;
using OzarkRecovery.Core.Services;
using OzarkRecovery.Infrastructure.Services;
using OzarkRecovery.Core.Domain.Model;
using OzarkRecovery.Core.Domain.Model.TreatmentStrategies;

namespace OzarkRecovery.Infrastructure.DependencyResolution
{
    public class BootStrapper
    {
        public static void RegisterIoC()
        {
            Database.SetInitializer(new ORContextInitializer());
            ObjectFactory.Initialize(x =>
            {
                x.For<IRepository>().Use<Repository>();
                x.For<DbContext>().Use<ORContext>();
                x.For<ISecurityContextService>().Use<SecurityContextService>();
                x.For<ITreatmentStrategy>().AddInstances(y =>
                    {
                        y.Type<OzarkRecoveryTreatmentStrategy>().Named("OzarkRecovery");
                        //add more strategy implementations for different facilities
                    });
            });
        }
    }

    public class ORContextInitializer : DropCreateDatabaseAlways<ORContext>
    {
        protected override void Seed(ORContext context)
        {
            context.Counselor.Add(new Counselor
            {
                FirstName = "Joe",
                LastName = "Super",
                UserName = "admin",
                Password = "admin",
                IsSupervisor = true,
                IsActive = true
            });

            var jane = context.Counselor.Add(new Counselor
            {
                FirstName = "Jane",
                LastName = "Doe",
                UserName = "jane",
                Password = "doe",
                IsSupervisor = false,
                IsActive = true
            });

            context.Client.Add(new Client
            {
                Id = 123,
                FirstName = "Jane",
                LastName = "Fonda",
            });

            context.Client.Add(new Client
            {
                Id = 124,
                FirstName = "Tom",
                LastName = "Hanks",
            });

            var hulk = context.Client.Add(new Client
            {
                Id = 125,
                FirstName = "The",
                LastName = "Hulk",
            });

            var strategy = ObjectFactory.GetNamedInstance<ITreatmentStrategy>("OzarkRecovery");
            var treatment = context.Treatment.Add(strategy.GenerateTreatment(hulk, jane));
            treatment.Advance();
            treatment.Advance();
            treatment.Advance();

            context.SaveChanges();

            base.Seed(context);
        }
    }
}


