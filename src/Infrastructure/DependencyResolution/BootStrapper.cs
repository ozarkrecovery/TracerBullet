
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using OzarkRecovery.Core.Domain.Interfaces;
using OzarkRecovery.Infrastructure.DataAccess.Impl;
using System.Data.Entity;
using OzarkRecovery.Infrastructure.DataAccess;
using OzarkRecovery.Core.Services;
using OzarkRecovery.Infrastructure.Services;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Infrastructure.DependencyResolution
{
    public class BootStrapper
    {
        public static void RegisterIoC()
        {
            Database.SetInitializer<ORContext>(new ORContextInitializer());
            ObjectFactory.Initialize(x =>
            {
                x.For<IRepository>().Use<Repository>();
                x.For<DbContext>().Use<ORContext>();
                x.For<ISecurityContextService>().Use<SecurityContextService>();
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
            context.Counselor.Add(new Counselor
            {
                FirstName = "Jane",
                LastName = "Doe",
                UserName = "jane",
                Password = "doe",
                IsSupervisor = false,
                IsActive = true
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}


