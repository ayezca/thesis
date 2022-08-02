using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;

namespace Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePatient(Patient patient)
        {
            Create(patient);           
        }

        public PagedList<Patient> GetAllPatients(PatientParameters patientParameters, bool trackChanges)
        {
            var patients = FindAll(trackChanges)
                .Search(patientParameters.SearchTerm)
                .Sort(patientParameters.OrderBy)
                //.OrderBy(c => c.Id)
                .ToList();

            return PagedList<Patient>
                .ToPagedList(patients, patientParameters.PageNumber,
                patientParameters.PageSize);
        }

        public Patient GetPatient(int id, bool trackChanges) => FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        public void DeletePatient(Patient patient)
        {
            Delete(patient);
        }

        public void UpdatePatient(Patient patient) =>
            Update(patient);

        public void GetPatientsExaminations(int id)
        {
            FindByCondition(x => x.Id == id, false)
            .Include(c => c.PatientsExaminations)
            .ThenInclude(c => c.Patient)
            .SingleOrDefault();
        }

        public void GetPatientsDiseases(int id) =>
            FindByCondition(x => x.Id == id, false)
            .Include(c => c.PatientsDiseases)
            .ThenInclude(c => c.Patient)
            .SingleOrDefault();

        public void GetPatientsVaccinations(int id) =>
            FindByCondition(x => x.Id == id, false)
            .Include(c => c.PatientsVaccinations)
            .ThenInclude(c => c.Patient)
            .SingleOrDefault();

        public void GetPatientsTreatments(int id)
        {
            FindByCondition(x => x.Id == id, false)
            .Include(c => c.PatientsTreatments)
            .ThenInclude(c => c.Patient)
            .SingleOrDefault();
        }
    }
}
