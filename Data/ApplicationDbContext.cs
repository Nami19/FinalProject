using Microsoft.EntityFrameworkCore;
using JwtAuthDemo.Models;


namespace JwtAuthDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Add DbSet properties here
        public DbSet<User>User { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<Educationalbackground> Educationalbackground { get; set; }
        public DbSet<CertificationsLicensces> CertificationsLicenses { get; set; }
        public DbSet<TrainingInfo> TrainingInfo { get; set; }
        public DbSet<WorkInfo> WorkInfo { get; set; }

        protected override void OnModelCreating(ModelBuildermodelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        } 
    }
}
