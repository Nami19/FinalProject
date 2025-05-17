using Microsoft.EntityFrameworkCore;
using JwtAuthDemo.Models.Info;
using System.Xml;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models
{
    public class Appdatacontext : DbContext
    {

        public Appdatacontext(DbContextOptions<Appdatacontext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<Educationalbackground> Educationalbackground { get; set; }
        public DbSet<GovernmentInfo> GovernmentInfo { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<CertificationsLicensces> CertificationsLicenses { get; set; }
        public DbSet<TrainingInfo> TrainingInfo { get; set; }
        public DbSet<WorkInfo> WorkInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configuration here
            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.BirthDate)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.HiredDate)
                .HasColumnType("timestamp with time zone");
        }



    }
}