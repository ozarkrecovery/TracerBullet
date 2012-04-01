using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OzarkRecovery.Core.Domain.Model;
using System.Data.Entity.ModelConfiguration;


namespace OzarkRecovery.Infrastructure.DataAccess
{
    public class ORContext : DbContext
    {
        public ORContext() : base("OzarkRecovery")
        {
            Database.Initialize(false);
        }

        //private static string connString = @"Data Source=sql2k8b.appliedi.net;Initial Catalog=ozarkrecovery;Persist Security Info=True;User ID=ozark;Password=recovery";
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Counselor> Counselor { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Phase> Phase { get; set; } 
        public DbSet<Screening> Screening { get; set; }
        public DbSet<Step> Step { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<Treatment> Treatment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
    public class AssignmentConfiguration : EntityTypeConfiguration<Assignment>
    {
        public AssignmentConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
    public class ClentConfiguration : EntityTypeConfiguration<Client>
    {
        public ClentConfiguration()
        {
            HasKey(c => c.Id);
            Property(p => p.FirstName).HasMaxLength(40);
            Property(p => p.FirstName).HasMaxLength(30);
            Ignore(p => p.FullName);
        }
    }

    public class CounselorConfiguration : EntityTypeConfiguration<Counselor>
    {
        public CounselorConfiguration()
        {
            HasKey(c => c.Id);
            Ignore(p => p.FullName);
        }
    }

    public class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
    public class MeetingConfiguration : EntityTypeConfiguration<Meeting>
    {
        public MeetingConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
    public class PhaseConfiguration : EntityTypeConfiguration<Phase>
    {
        public PhaseConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
    public class ScreeningConfiguration : EntityTypeConfiguration<Screening>
    {
        public ScreeningConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
    public class StepConfiguration : EntityTypeConfiguration<Step>
    {
        public StepConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
    public class SurveyConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
    public class TreatmentConfiguration : EntityTypeConfiguration<Treatment>
    {
        public TreatmentConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
}