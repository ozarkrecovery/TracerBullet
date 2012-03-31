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

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientEvent> ClientEvent { get; set; }
        public DbSet<ClientEventDesc> ClientEventDesc { get; set; }
        public DbSet<Counselor> Counselor { get; set; }
        public DbSet<Phase> Phase { get; set;} 
        public DbSet<Program> Program { get; set; }
        public DbSet<Treatment> Treatment { get; set; }



        public ORContext() : base(connString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Client>().HasKey(c=>c.Id);
            modelBuilder.Entity<ClientEvent>().HasKey(c => c.Id);
            modelBuilder.Entity<ClientEventDesc>().HasKey(c => c.Id);
            modelBuilder.Entity<Counselor>().HasKey(c => c.Id);
            modelBuilder.Entity<Phase>().HasKey(p => p.Id);
            modelBuilder.Entity<Program>().HasKey(p => p.Id);
            modelBuilder.Entity<Treatment>().HasKey(t => t.Id);
            //modelBuilder.Entity<Order>().Map(o => o.ToTable("Ord"));
            //modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            //modelBuilder.Entity<Order>().Property(x => x.OrderId).HasColumnName("OrdID");
        }
    }
}