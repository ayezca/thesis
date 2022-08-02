using System;
using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());
            //modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<DoctorsOrganization> DoctorsOrganizations { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<PatientsDisease> PatientsDiseases { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<PatientsVaccination> PatientsVaccinations { get; set; }
        public DbSet<LifeAnamnesis> LifeAnamneses { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<PatientsTreatment> PatientsTreatments { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<PatientsExamination> PatientsExaminations { get; set; }
        public DbSet<DiseaseAnamnesis> DiseaseAnamneses { get; set; }

    }
}
