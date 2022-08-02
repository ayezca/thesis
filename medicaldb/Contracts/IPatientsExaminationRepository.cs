using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IPatientsExaminationRepository
    {
        void CreateExaminationForPatient(int patientId, int examinationId, int doctorId, PatientsExamination patientsExamination);
        IEnumerable<PatientsExamination> GetAllExaminations(int patientId, bool trackChanges);
        PatientsExamination GetPatientsExamination(int patientId, int examinationId, int doctorId, int id, bool trackChanges);
        //void UpdatePatientsExamination(PatientsExamination complain);
        void DeletePatientsExamination(PatientsExamination patientsExamination);
    }
}
 