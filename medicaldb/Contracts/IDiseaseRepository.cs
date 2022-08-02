using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IDiseaseRepository
    {
        void CreateDisease(Disease disease);
        IEnumerable<Disease> GetAllDiseases(bool trackChanges);
        Disease GetDisease(int id, bool trackChanges);
        void UpdateDisease(Disease disease);
        void DeleteDisease(Disease disease);
    }
}
