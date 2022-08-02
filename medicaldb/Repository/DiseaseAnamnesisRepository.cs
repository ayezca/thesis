using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class DiseaseAnamnesisRepository : RepositoryBase<DiseaseAnamnesis>, IDiseaseAnamnesisRepository
    {
        public DiseaseAnamnesisRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDiseaseAnamnesisForPatient(int patientId, DiseaseAnamnesis diseaseAnamnesis)
        {
            diseaseAnamnesis.PatientId = patientId;
            Create(diseaseAnamnesis);
        }

        public IEnumerable<DiseaseAnamnesis> GetAllDiseaseAnamneses(int patientId, bool trackChanges) =>
            FindByCondition(x => x.PatientId == patientId, trackChanges).ToList();

        public DiseaseAnamnesis GetDiseaseAnamnesis(int patientId, int id, bool trackChanges) =>
            FindByCondition(x => x.PatientId == patientId && x.Id == id, trackChanges).SingleOrDefault();

        //public void Update(int id, Complain complain) => Update(complain);

        public void DeleteDiseaseAnamnesis(DiseaseAnamnesis diseaseAnamnesis) => Delete(diseaseAnamnesis);

        //TODO update 
    }
}
