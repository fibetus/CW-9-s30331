using APBD_CW9.Data;
using APBD_CW9.DTOs;
using APBD_CW9.DTOs.DoctorDTOs;
using APBD_CW9.DTOs.MedicamentDTOs;
using APBD_CW9.DTOs.PrescriptionDTOs;
using APBD_CW9.Exceptions;
using APBD_CW9.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_CW9.Services;

public interface IDbService
{
    public Task<PrescriptionGetDto> AddPrescriptionAsync(PrescriptionCreateDto prescriptionCreateDto);
    public Task<PatientGetDto> GetPatientDetailsAsync(int idPatient);
}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<PrescriptionGetDto> AddPrescriptionAsync(PrescriptionCreateDto prescriptionCreateDto)
    {
        // Checking medicament requirements
        if (prescriptionCreateDto.DueDate < prescriptionCreateDto.Date)
        {
            throw new InvalidDateException($"DueDate: {prescriptionCreateDto.DueDate} cannot be earlier than Date: {prescriptionCreateDto.Date}.");
        }

        if (prescriptionCreateDto.Medicaments.Count > 10)
        {
            throw new MedicamentsLimitException($"Prescription cannot have more than 10 medicaments. Current count: {prescriptionCreateDto.Medicaments.Count}.");
        }
        var medicamentIds = prescriptionCreateDto.Medicaments.Select( m => m.IdMedicament).ToList();
        var alreadyExistsMedicaments = await data.Medicaments
            .Where(m => medicamentIds.Contains(m.IdMedicament))
            .ToListAsync();
        if (alreadyExistsMedicaments.Count != medicamentIds.Distinct().Count())
        {
            var idNotFoundMedicaments = medicamentIds.Except(alreadyExistsMedicaments.Select(m => m.IdMedicament));
            throw new MedicamentNotFoundException($"Medicaments with IDs {string.Join(", ", idNotFoundMedicaments)} not found.");
        }

        // Checking patients existence and creating new one if is not found (without ID provided, else -> Exception)
        Patient patient;
        if (prescriptionCreateDto.Patient.IdPatient.HasValue)
        {
            patient = await data.Patients.FindAsync(prescriptionCreateDto.Patient.IdPatient.Value);
            if (patient == null)
            {
                throw new PatientNotFoundException($"Patient with ID {prescriptionCreateDto.Patient.IdPatient} was not found.");
            }
        }
        else
        {
            patient = new Patient
            {
                FirstName = prescriptionCreateDto.Patient.FirstName,
                LastName = prescriptionCreateDto.Patient.LastName,
                Birthdate = prescriptionCreateDto.Patient.Birthdate
            };
            data.Patients.Add(patient);
            await data.SaveChangesAsync();
        }
        
        // Checking doctor existence
        var doctor = await data.Doctors.FindAsync(prescriptionCreateDto.Doctor.IdDoctor);
        if (doctor == null)
        {
            throw new DoctorNotFoundException($"Doctor with ID {prescriptionCreateDto.Doctor.IdDoctor} does not exist.");
        }

        var prescription = new Prescription
        {
            Date = prescriptionCreateDto.Date,
            DueDate = prescriptionCreateDto.DueDate,
            IdPatient = patient.IdPatient,
            Patient = patient,
            IdDoctor = doctor.Id,
            Doctor = doctor,
        };
        data.Prescriptions.Add(prescription);
        await data.SaveChangesAsync();
        
        // Adding medicaments to prescription
        foreach (var medicamentDto in prescriptionCreateDto.Medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = medicamentDto.IdMedicament,
                Dose = medicamentDto.Dose,
                Details = medicamentDto.Details,
            };
            data.PrescriptionMedicaments.Add(prescriptionMedicament);
        }
        await data.SaveChangesAsync();

        return new PrescriptionGetDto
        {
            IdPrescription = prescription.IdPrescription,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            Doctor = new DoctorPrescriptionGetDto
            {
                IdDoctor = doctor.Id,
                FirstName = doctor.FirstName,
            },
            Medicaments = alreadyExistsMedicaments.Select(aem =>
            {
                var medicamentPrescriptionGet = prescriptionCreateDto.Medicaments.First(mDto => mDto.IdMedicament == aem.IdMedicament);
                return new MedicamentPrescriptionGetDto
                {
                    IdMedicament = aem.IdMedicament,
                    Name = aem.Name,
                    Description = aem.Description,
                    Dose = medicamentPrescriptionGet.Dose
                };
            }).ToList()
        };
    }

    public async Task<PatientGetDto> GetPatientDetailsAsync(int idPatient)
    {
        var patient = await data.Patients
            .Include(p => p.Prescriptions)
                .ThenInclude(p => p.PrescriptionMedicaments)
            .Include(p => p.Prescriptions)
                .ThenInclude(p => p.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
            .Where(p => p.IdPatient == idPatient)
            .Select(p => new PatientGetDto
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate,
                Prescriptions = p.Prescriptions
                    .OrderBy(pr => pr.DueDate)
                    .Select(pr => new PrescriptionGetDto
                    {
                        IdPrescription = pr.IdPrescription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Doctor = new DoctorPrescriptionGetDto
                        {
                            IdDoctor = pr.IdDoctor,
                            FirstName = p.FirstName,
                        },
                        Medicaments = pr.PrescriptionMedicaments.Select(pm => new MedicamentPrescriptionGetDto
                        {
                            IdMedicament = pm.IdMedicament,
                            Name = pm.Medicament.Name,
                            Dose = pm.Dose,
                            Description = pm.Medicament.Description
                        }).ToList()
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        if (patient == null)
        {
            throw new PatientNotFoundException($"Patient with ID {idPatient} was not found.");
        }
        
        return patient;
    }
}