using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ComplainRepository : RepositoryBase<Complain>, IComplainRepository
    {
        public ComplainRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateComplainForPatient(int patientId, Complain complain)
        {
            complain.PatientId = patientId;
            Create(complain);
        }

        public IEnumerable<Complain> GetAllComplains(int patientId, bool trackChanges) => FindByCondition(x => x.PatientId == patientId, trackChanges).ToList();

        public Complain GetComplain(int patientId, int id, bool trackChanges) => FindByCondition(x => x.PatientId == patientId && x.Id == id, trackChanges).SingleOrDefault();

        public void UpdateComplain(Complain complain) => Update(complain);

        public void DeleteComplain(Complain complain) => Delete(complain);

    }
}
