
using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class TreatmentRepository : RepositoryBase<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateTreatment(Treatment treatment)
        {
            Create(treatment);
        }

        public IEnumerable<Treatment> GetAllTreatments(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();

        public Treatment GetTreatment(int id, bool trackChanges) =>
            FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        public void UpdateTreatment(Treatment treatment) => Update(treatment);
    }
}
