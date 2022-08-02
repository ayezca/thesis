using System;
using System.Collections.Generic;
using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IPatientRepository
    {
        PagedList<Patient> GetAllPatients(PatientParameters patientParameters, bool trackChanges);
        Patient GetPatient(int id, bool trackChanges);
        void CreatePatient(Patient patient);
        void DeletePatient(Patient patient);
        void UpdatePatient(Patient patient);

        void GetPatientsDiseases(int id);
        void GetPatientsVaccinations(int id);
        void GetPatientsTreatments(int id);
    }
}
