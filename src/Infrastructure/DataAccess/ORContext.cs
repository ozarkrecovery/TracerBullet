using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OzarkRecovery.Core;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Infrastructure.DataAccess
{
    public class ORContext : DbContext
    {
        private static string connString = @"Data Source=sql2k8b.appliedi.net;Initial Catalog=Ozarkrecovery;Persist Security Info=True;User ID=ozark;Password=recovery";

        public DbSet<Client> Patient { get; set; }
        public DbSet<Phase> Phase { get; set; }

        public ORContext() : base(connString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Order>().Map(o => o.ToTable("Ord"));
            //modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            //modelBuilder.Entity<Order>().Property(x => x.OrderId).HasColumnName("OrdID");
        }
    }
}