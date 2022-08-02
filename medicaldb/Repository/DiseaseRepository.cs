using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class DiseaseRepository : RepositoryBase<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDisease(Disease disease)
        {
            Create(disease);
        }

        public IEnumerable<Disease> GetAllDiseases(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();

        public Disease GetDisease(int id, bool trackChanges) =>
            FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        public void UpdateDisease(Disease disease) => Update(disease);

        public void DeleteDisease(Disease disease) => Delete(disease);

    }
}
