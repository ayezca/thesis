using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class PatientsExaminationRepository : RepositoryBase<PatientsExamination>, IPatientsExaminationRepository
    {
        public PatientsExaminationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateExaminationForPatient(int patientId, int examinationId, int doctorId, PatientsExamination patientsExamination)
        {
            patientsExamination.PatientId = patientId;
            patientsExamination.ExaminationId = examinationId;
            Create(patientsExamination);
        }

        public void DeletePatientsExamination(PatientsExamination patientsExamination) => Delete(patientsExamination);

        public IEnumerable<PatientsExamination> GetAllExaminations(int patientId, bool trackChanges) => FindByCondition(x => x.PatientId == patientId, trackChanges).ToList();

        public PatientsExamination GetPatientsExamination(int patientId, int examinationId, int doctorId, int id, bool trackChanges) => FindByCondition(x => x.PatientId == patientId && x.Id == id, trackChanges).SingleOrDefault();
    }
}
