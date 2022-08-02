using System;
namespace Contracts
{
    public interface IRepositoryManager
    {
        IComplainRepository Complain { get; }
        IDiseaseAnamnesisRepository DiseaseAnamnesis { get; }
        IDiseaseRepository Disease { get; }
        IDoctorRepository Doctor { get; }
        IExaminationRepository Examination { get; }
        ILifeAnamnesisRepository LifeAnamnesis { get; }
        IOrganizationRepository Organization { get; }
        IPatientRepository Patient { get; }
        ISpecialtyRepository Specialty { get; }
        ITreatmentRepository Treatment { get; }
        IVaccinationRepository Vaccination { get; }
        IPatientsExaminationRepository PatientsExamination { get; }

        void Save();
    }
}
