using APBD_CW9.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_CW9.Data;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });


        var doctor = new Doctor
        {
            Id = 1,
            FirstName = "Pepper",
            LastName = "Oetker",
            Email = "pepper@gmail.com",
        };

        var patient = new Patient
        {
            IdPatient = 1,
            FirstName = "Peter",
            LastName = "Parker",
            Birthdate = new DateTime(1980, 1, 1),
        };

        var medicament = new Medicament
        {
            IdMedicament = 1,
            Name = "Trenbolon",
            Description = "Anabolic Steroid",
            Type = "Injective"
        };

        var prescription = new Prescription
        {
            IdPrescription = 1,
            Date = new DateTime(2025, 5, 27),
            DueDate = new DateTime(2025, 7, 15),
            IdPatient = 1,
            IdDoctor = 1
        };

        var prescriptionMedicament = new PrescriptionMedicament
        {
            IdPrescription = 1,
            IdMedicament = 1,
            Dose = 400,
            Details = "Inject into big muscle group"
        };
        
        
        modelBuilder.Entity<Doctor>().HasData([doctor]);
        modelBuilder.Entity<Patient>().HasData([patient]);
        modelBuilder.Entity<Medicament>().HasData([medicament]);
        modelBuilder.Entity<Prescription>().HasData([prescription]);
        modelBuilder.Entity<PrescriptionMedicament>().HasData([prescriptionMedicament]);
    }
}