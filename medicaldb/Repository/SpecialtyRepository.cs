using System;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class SpecialtyRepository : RepositoryBase<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
