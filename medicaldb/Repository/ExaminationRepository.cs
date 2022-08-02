using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ExaminationRepository : RepositoryBase<Examination>, IExaminationRepository
    {
        public ExaminationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateExamination(Examination examination)
        {
            Create(examination);
        }

        public IEnumerable<Examination> GetAllExaminations(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();

        public Examination GetExamination(int id, bool trackChanges) =>
            FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        public void UpdateExamination(Examination examination) => Update(examination);

        public void DeleteExamination(Examination examination) => Delete(examination);
    }
}
