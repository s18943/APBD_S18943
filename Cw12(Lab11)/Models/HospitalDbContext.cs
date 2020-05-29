using Cw12_Lab11_.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw12_Lab11_.Models
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescriptions_Medicaments { get; set; }
        public HospitalDbContext() 
        { 
        
        }
        public HospitalDbContext(DbContextOptions options):base(options) 
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorConfig());

            var doctors = new List<Doctor>();
            doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Larry", LastName = "Shwarcenberg", Email = "L.Shwarcenberg@hospital.com" });
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Garry", LastName = "Dalton", Email = "Dalton.G@hospital.com" });
            doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Frederic", LastName = "Lamerke", Email = "F.Lamerke@hospital.com" });
            modelBuilder.Entity<Doctor>().HasData(doctors);

            modelBuilder.ApplyConfiguration(new PatientConfig());
            var patients = new List<Patient>();
            patients.Add(new Patient { IdPatient = 1, FirstName = "Susan", LastName = "Hearton", BirdthDate = DateTime.Parse("1993-11-05T05:05:05") });
            patients.Add(new Patient { IdPatient = 2, FirstName = "Betty", LastName = "Black", BirdthDate = DateTime.Parse("1997-09-08T10:09:05") });
            patients.Add(new Patient { IdPatient = 3, FirstName = "Jessica", LastName = "Kolt", BirdthDate = DateTime.Parse("1983-05-29T03:30:00") });
            modelBuilder.Entity<Patient>().HasData(patients);

            modelBuilder.ApplyConfiguration(new PrescriptionConfig());
            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription { IdPrescription = 1, Date = DateTime.Parse("2000-03-30T23:00:00"), DueDate = DateTime.Parse("2000-04-07T00:00:00"), IdPatient = 1, IdDoctor = 1 });
            prescriptions.Add(new Prescription { IdPrescription = 2, Date = DateTime.Parse("2000-03-20T22:00:00"), DueDate = DateTime.Parse("2000-05-02T00:00:00"), IdPatient = 2, IdDoctor = 2 });
            prescriptions.Add(new Prescription { IdPrescription = 3, Date = DateTime.Parse("2000-03-10T21:00:00"), DueDate = DateTime.Parse("2000-06-06T00:00:00"), IdPatient = 3, IdDoctor = 3 });
            modelBuilder.Entity<Prescription>().HasData(prescriptions);

            modelBuilder.ApplyConfiguration(new MedicamentConfig());
            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament { IdMedicament = 1, Name = "Cetrine", Description = "Antigistamine", Type = "Anti-Alegetic" });
            medicaments.Add(new Medicament { IdMedicament = 2, Name = "Vitamine", Description = "D3,B2,Calcium", Type = "Supliment" });
            medicaments.Add(new Medicament { IdMedicament = 3, Name = "Satotrean", Description = "Hearbs to calm down)))", Type = "Anti_DIpresant" });
            modelBuilder.Entity<Medicament>().HasData(medicaments);

            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });
            modelBuilder.Entity<Prescription_Medicament>()
                .Property(d => d.Dose);
            modelBuilder.Entity<Prescription_Medicament>()
                .Property(d => d.Details).HasMaxLength(300).IsRequired();
            var prescriptionsMedicaments = new List<Prescription_Medicament>();
            prescriptionsMedicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Two times a Day" });
            prescriptionsMedicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "Before Meal" });
            prescriptionsMedicaments.Add(new Prescription_Medicament { IdMedicament = 3, IdPrescription = 3, Dose = 3, Details = "After meal" });
            modelBuilder.Entity<Prescription_Medicament>().HasData(prescriptionsMedicaments);

        }
    }
}
