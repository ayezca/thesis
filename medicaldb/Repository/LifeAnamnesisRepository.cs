using System;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class LifeAnamnesisRepository : RepositoryBase<LifeAnamnesis>, ILifeAnamnesisRepository
    {
        public LifeAnamnesisRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateLifeAnamnesisForPatient(int patientId, LifeAnamnesis lifeAnamnesis)
        {
            lifeAnamnesis.PatientId = patientId;
            Create(lifeAnamnesis);
        }

        public LifeAnamnesis GetLifeAnamnesis(int patientId, int id, bool trackChanges) =>
            FindByCondition(x => x.PatientId == patientId && x.Id == id, trackChanges).SingleOrDefault();

        //public void Update(int id, Complain complain) => Update(complain);

        public void DeleteLifeAnamnesis(LifeAnamnesis lifeAnamnesis) => Delete(lifeAnamnesis);

        //TODO update 
    }
}
