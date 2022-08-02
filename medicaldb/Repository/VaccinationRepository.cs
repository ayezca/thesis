using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class VaccinationRepository : RepositoryBase<Vaccination>, IVaccinationRepository
    {
        public VaccinationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateVaccination(Vaccination vaccination)
        {
            Create(vaccination);
        }

        public IEnumerable<Vaccination> GetAllVaccinations(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();

        public Vaccination GetVaccination(int id, bool trackChanges) =>
            FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        public void UpdateVaccination(Vaccination vaccination) => Update(vaccination);

    }
}
