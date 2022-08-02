using System;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IComplainRepository _complainRepository;
        private IDiseaseAnamnesisRepository _diseaseAnamnesisRepository;
        private IDiseaseRepository _diseaseRepository;
        private IDoctorRepository _doctorRepository;
        private IExaminationRepository _examinationRepository;
        private ILifeAnamnesisRepository _lifeAnamnesisRepository;
        private IOrganizationRepository _organizationRepository;
        private IPatientRepository _patientRepository;
        private ISpecialtyRepository _specialtyRepository;
        private ITreatmentRepository _treatmentRepository;
        private IVaccinationRepository _vaccinationRepository;
        private IPatientsExaminationRepository _patientsExaminationRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IComplainRepository Complain
        {
            get
            {
                if (_complainRepository == null)
                {
                    _complainRepository = new ComplainRepository(_repositoryContext);
                }

                return _complainRepository;
            }
        }

        public IDiseaseAnamnesisRepository DiseaseAnamnesis
        {
            get
            {
                if (_diseaseAnamnesisRepository == null)
                {
                    _diseaseAnamnesisRepository = new DiseaseAnamnesisRepository(_repositoryContext);
                }

                return _diseaseAnamnesisRepository;
            }
        }

        public IDiseaseRepository Disease
        {
            get
            {
                if (_diseaseRepository == null)
                {
                    _diseaseRepository = new DiseaseRepository(_repositoryContext);
                }

                return _diseaseRepository;
            }
        }

        public IDoctorRepository Doctor
        {
            get
            {
                if (_doctorRepository == null)
                {
                    _doctorRepository = new DoctorRepository(_repositoryContext);
                }

                return _doctorRepository;
            }
        }

        public IExaminationRepository Examination
        {
            get
            {
                if (_examinationRepository == null)
                {
                    _examinationRepository = new ExaminationRepository(_repositoryContext);
                }

                return _examinationRepository;
            }
        }

        public ILifeAnamnesisRepository LifeAnamnesis
        {
            get
            {
                if (_lifeAnamnesisRepository == null)
                {
                    _lifeAnamnesisRepository = new LifeAnamnesisRepository(_repositoryContext);
                }

                return _lifeAnamnesisRepository;
            }      
        }

        public IOrganizationRepository Organization
        {
            get
            {
                if (_organizationRepository == null) {
                    _organizationRepository = new OrganizationRepository(_repositoryContext);
                }

                return _organizationRepository;
            }
        }

        public IPatientRepository Patient
        {
            get
            {
                if (_patientRepository == null) {
                    _patientRepository = new PatientRepository(_repositoryContext);
                }

                return _patientRepository;
            }
        }

        public ISpecialtyRepository Specialty
        {
            get
            {
                if (_specialtyRepository == null)
                {
                    _specialtyRepository = new SpecialtyRepository(_repositoryContext);
                }

                return _specialtyRepository;
            }
        }

        public ITreatmentRepository Treatment
        {
            get
            {
                if (_treatmentRepository == null)
                {
                    _treatmentRepository = new TreatmentRepository(_repositoryContext);
                }

                return _treatmentRepository;
            }
        }

        public IVaccinationRepository Vaccination
        {
            get
            {
                if (_vaccinationRepository == null)
                {
                    _vaccinationRepository = new VaccinationRepository(_repositoryContext);
                }

                return _vaccinationRepository;
            }
        }

        public IPatientsExaminationRepository PatientsExamination
        {
            get
            {
                if (_patientsExaminationRepository == null)
                {
                    _patientsExaminationRepository = new PatientsExaminationRepository(_repositoryContext);
                }

                return _patientsExaminationRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
